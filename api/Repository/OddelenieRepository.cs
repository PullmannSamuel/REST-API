using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Department;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext context;
        public DepartmentRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Department> CreateAsync(Department departmentModel)
        {
            var project = await context.projects.FirstOrDefaultAsync(p => p.id == departmentModel.projectId);

            if (project == null) {
                return departmentModel;
            }

            await context.departments.AddAsync(departmentModel);
            await context.SaveChangesAsync();

            project.departmentsId.Add(departmentModel.id);
            await context.SaveChangesAsync();

            var department = await context.departments
                .Include(x => x.headOfDepartment)
                .FirstOrDefaultAsync(x => x.id == departmentModel.id);

            if (department != null) {
                return department;
            }

            return departmentModel;
        }

        public async Task<Department?> DeleteAsync(int id)
        {
            var department = await context.departments.FirstOrDefaultAsync(o => o.id == id);

            if (department == null) {
                return null;
            }

            context.departments.Remove(department);
            await context.SaveChangesAsync();

            var project = await context.projects.FirstOrDefaultAsync(p => p.id == department.projectId);

            if (project != null) {
                project.departmentsId.Remove(department.id);
                await context.SaveChangesAsync();
            }

            return department;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await context.departments
                .Include(o => o.headOfDepartment).ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await context.departments
                .Include(o => o.headOfDepartment).FirstOrDefaultAsync(o => o.id == id);
        }

        public async Task<Department?> UpdateAsync(int projectId, int departmentId, UpdateDepartmentRequestDto departmentDto)
        {
            var departmentModel = await context.departments
                .Include(o => o.headOfDepartment)
                .FirstOrDefaultAsync(o => o.id == departmentId);

            if (departmentModel == null) {
                return null;
            }

            if (departmentModel.projectId != projectId) {
                var removeFromProject = await context.projects.FirstOrDefaultAsync(p => p.id == departmentModel.projectId);
                var addToProject = await context.projects.FirstOrDefaultAsync(p => p.id == projectId);

                if (removeFromProject != null) {
                    removeFromProject.departmentsId.Remove(departmentId);
                }

                if (addToProject == null) {
                    return null;
                }

                addToProject.departmentsId.Add(departmentId);
            }

            departmentModel.name = departmentDto.name;
            departmentModel.code = departmentDto.code;
            departmentModel.headOfDepartmentId = departmentDto.headOfDepartmentId;
            departmentModel.projectId = projectId;

            await context.SaveChangesAsync();

            return departmentModel;
        }
    }
}