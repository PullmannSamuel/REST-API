using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Divizia;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class DiviziaMappers
    {
        public static DiviziaDto ToDiviziaDto(this Divizia diviziaModel)
        {
            return new DiviziaDto
            {
                id = diviziaModel.id,
                nazov = diviziaModel.nazov,
                kod = diviziaModel.kod,
                veduciDivizieId = diviziaModel.veduciDivizieId,
                menoVeduceho = diviziaModel.veduciDivizie != null
                    ? $"{diviziaModel.veduciDivizie.meno} {diviziaModel.veduciDivizie.priezvisko}" 
                    : "vedúci nebol pridelený",
                projektyId = diviziaModel.projektyId,
                firmaId = diviziaModel.firmaId
            };
        }

        public static Divizia ToDiviziaFromCreate(this CreateDiviziaDto diviziaDto, int firmaId)
        {
            return new Divizia
            {
                nazov = diviziaDto.nazov,
                kod = diviziaDto.kod,
                veduciDivizieId = diviziaDto.veduciDivizieId,
                firmaId = firmaId
            };
        }
    }
}