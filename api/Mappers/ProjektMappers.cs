using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Projekt;
using api.Models;

namespace api.Mappers
{
    public static class ProjektMappers
    {
        public static ProjektDto ToProjektDto(this Projekt projektModel)
        {
            return new ProjektDto
            {
                id = projektModel.id,
                nazov = projektModel.nazov,
                kod = projektModel.kod,
                veduciProjektuId = projektModel.veduciProjektuId,
                menoVeduceho = projektModel.veduciProjektu != null
                    ? $"{projektModel.veduciProjektu.meno} {projektModel.veduciProjektu.priezvisko}" 
                    : "vedúci nebol pridelený",
                oddeleniaId = projektModel.oddeleniaId,
                diviziaId = projektModel.diviziaId
            };
        }

        public static Projekt ToProjektFromCreate(this CreateProjektDto projektDto, int diviziaId)
        {
            return new Projekt
            {
                nazov = projektDto.nazov,
                kod = projektDto.kod,
                veduciProjektuId = projektDto.veduciProjektuId,
                diviziaId = diviziaId
            };
        }
    }
}