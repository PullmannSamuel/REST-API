using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Firma;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class FirmaMappers
    {
        public static FirmaDto ToFirmaDto(this Firma firmaModel)
        {
            return new FirmaDto
            {
                id = firmaModel.id,
                nazov = firmaModel.nazov,
                kod = firmaModel.kod,
                riaditelId = firmaModel.riaditelId,
                menoVeduceho = firmaModel.riaditel != null 
                    ? $"{firmaModel.riaditel.meno} {firmaModel.riaditel.priezvisko}" 
                    : "vedúci nebol pridelený",
                divizieId = firmaModel.divizieId
            };
        }

        public static Firma ToFirmaFromCreateDto(this CreateFirmaRequestDto firmaDto) 
        {
            return new Firma
            {
                nazov = firmaDto.nazov,
                kod = firmaDto.kod,
                riaditelId = firmaDto.riaditelId,
            };
        } 
    }
}