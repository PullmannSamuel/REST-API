using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Company;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class CompanyMappers
    {
        public static CompanyDto ToCompanyDto(this Company companyModel)
        {
            return new CompanyDto
            {
                id = companyModel.id,
                name = companyModel.name,
                code = companyModel.code,
                directorId = companyModel.directorId,
                leaderName = companyModel.director != null 
                    ? $"{companyModel.director.firstName} {companyModel.director.lastName}" 
                    : "leader couldnt be found",
                divisionsId = companyModel.divisionsId
            };
        }

        public static Company ToCompanyFromCreateDto(this CreateCompanyRequestDto companyDto) 
        {
            return new Company
            {
                name = companyDto.name,
                code = companyDto.code,
                directorId = companyDto.directorId,
            };
        } 
    }
}