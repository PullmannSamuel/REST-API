using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Division;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class DivisionMappers
    {
        public static DivisionDto ToDivisionDto(this Division divisionModel)
        {
            return new DivisionDto
            {
                id = divisionModel.id,
                name = divisionModel.name,
                code = divisionModel.code,
                headOfDivisionId = divisionModel.headOfDivisionId,
                leaderName = divisionModel.headOfDivision != null
                    ? $"{divisionModel.headOfDivision.firstName} {divisionModel.headOfDivision.lastName}" 
                    : "leader couldnt be found",
                projectsId = divisionModel.projectsId,
                companyId = divisionModel.companyId
            };
        }

        public static Division ToDivisionFromCreate(this CreateDivisionDto diviziaDto, int companyId)
        {
            return new Division
            {
                name = diviziaDto.name,
                code = diviziaDto.code,
                headOfDivisionId = diviziaDto.headOfDivisionId,
                companyId = companyId
            };
        }
    }
}