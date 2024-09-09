using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Department;
using api.Models;

namespace api.Mappers
{
    public static class DepartmentMappers
    {
        public static DepartmentDto ToDepartmentDto(this Department departmentModel)
        {
            return new DepartmentDto
            {
                id = departmentModel.id,
                name = departmentModel.name,
                code = departmentModel.code,
                headOfDepartmentId = departmentModel.headOfDepartmentId,
                leaderName = departmentModel.headOfDepartment != null
                    ? $"{departmentModel.headOfDepartment.firstName} {departmentModel.headOfDepartment.lastName}" 
                    : "leader couldnt be found",
                projectId = departmentModel.projectId
            };
        }

        public static Department ToDepartmentFromCreate(this CreateDepartmentDto departmentDto, int projectId)
        {
            return new Department
            {
                name = departmentDto.name,
                code = departmentDto.code,
                headOfDepartmentId = departmentDto.headOfDepartmentId,
                projectId = projectId
            };
        }
    }
}