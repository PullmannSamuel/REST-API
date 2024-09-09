using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Oddelenie;
using api.Models;

namespace api.Mappers
{
    public static class OddelenieMappers
    {
        public static OddelenieDto ToOddelenieDto(this Oddelenie oddelenieModel)
        {
            return new OddelenieDto
            {
                id = oddelenieModel.id,
                nazov = oddelenieModel.nazov,
                kod = oddelenieModel.kod,
                veduciOddeleniaId = oddelenieModel.veduciOddeleniaId,
                menoVeduceho = oddelenieModel.veduciOddelenia != null
                    ? $"{oddelenieModel.veduciOddelenia.meno} {oddelenieModel.veduciOddelenia.priezvisko}" 
                    : "vedúci nebol pridelený",
                projektId = oddelenieModel.projektId
            };
        }

        public static Oddelenie ToOddelenieFromCreate(this CreateOddelenieDto oddelenieDto, int projektId)
        {
            return new Oddelenie
            {
                nazov = oddelenieDto.nazov,
                kod = oddelenieDto.kod,
                veduciOddeleniaId = oddelenieDto.veduciOddeleniaId,
                projektId = projektId
            };
        }
    }
}