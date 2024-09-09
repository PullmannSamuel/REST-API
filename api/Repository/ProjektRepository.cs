using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Project;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDBContext context;
        public ProjectRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Project> CreateAsync(Project projectModel)
        {
            var division = await context.divisions.FirstOrDefaultAsync(d => d.id == projectModel.divisionId);
            
            if (division == null) {
                return projectModel;
            }

            await context.projects.AddAsync(projectModel);
            await context.SaveChangesAsync();

            division.projectsId.Add(projectModel.id);
            await context.SaveChangesAsync();

            var project = await context.projects
                .Include(x => x.projectManager)
                .FirstOrDefaultAsync(x => x.id == projectModel.id);

            if (project != null) {
                return project;
            }

            return projectModel;
        }

        public async Task<Project?> DeleteAsync(int id)
        {
            var project = await context.projects.FirstOrDefaultAsync(p => p.id == id);

            if (project == null) {
                return null;
            }

            context.projects.Remove(project);
            await context.SaveChangesAsync();

            var division = await context.divisions.FirstOrDefaultAsync(d => d.id == project.divisionId);

            if (division != null) {
                division.projectsId.Remove(project.id);
                await context.SaveChangesAsync();
            }

            return project;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await context.projects
                .Include(p => p.projectManager).ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await context.projects
                .Include(p => p.projectManager).FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Project?> UpdateAsync(int divisionId, int projectId, UpdateProjectRequestDto projectDto)
        {
            var projectModel = await context.projects
                .Include(p => p.projectManager)
                .FirstOrDefaultAsync(p => p.id == projectId);

            if (projectModel == null) {
                return null;
            }

            if (projectModel.divisionId != divisionId) {
                var removeFromDivision = await context.divisions.FirstOrDefaultAsync(d => d.id == projectModel.divisionId);
                var addToDivision = await context.divisions.FirstOrDefaultAsync(d => d.id == divisionId);

                if (removeFromDivision != null) {
                    removeFromDivision.projectsId.Remove(projectId);
                }

                if (addToDivision == null) {
                    return null;
                }

                addToDivision.projectsId.Add(projectId);
            }

            projectModel.name = projectDto.name;
            projectModel.code = projectDto.code;
            projectModel.projectManagerId = projectDto.projectManagerId;
            projectModel.divisionId = divisionId;

            await context.SaveChangesAsync();

            return projectModel;
        }

        public async Task<bool> ProjectExists(int id)
        {
            return await context.projects.AnyAsync(p => p.id == id);
        }
    }
}