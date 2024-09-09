using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Project;
using api.Models;

namespace api.Mappers
{
    public static class ProjectMappers
    {
        public static ProjectDto ToProjectDto(this Project projectModel)
        {
            return new ProjectDto
            {
                id = projectModel.id,
                name = projectModel.name,
                code = projectModel.code,
                projectManagerId = projectModel.projectManagerId,
                leaderName = projectModel.projectManager != null
                    ? $"{projectModel.projectManager.firstName} {projectModel.projectManager.lastName}" 
                    : "leader couldnt be found",
                departmentsId = projectModel.departmentsId,
                divisionId = projectModel.divisionId
            };
        }

        public static Project ToProjectFromCreate(this CreateProjectDto projectDto, int divisionId)
        {
            return new Project
            {
                name = projectDto.name,
                code = projectDto.code,
                projectManagerId = projectDto.projectManagerId,
                divisionId = divisionId
            };
        }
    }
}