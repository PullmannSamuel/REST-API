using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Zamestnanec;
using api.Models;

namespace api.Mappers
{
    public static class ZamestnanecMappers
    {
        public static ZamestnanecDto ToZamestnanecDto(this Zamestnanec zamestModel)
        {
            return new ZamestnanecDto
            {
                id = zamestModel.id,
                titul = zamestModel.titul,
                meno = zamestModel.meno,
                priezvisko = zamestModel.priezvisko,
                telefon = zamestModel.telefon,
                email = zamestModel.email
            };
        }

        public static Zamestnanec ToZamestnanecFromCreateDto(this CreateZamestnanecRequest zamestDto)
        {
            return new Zamestnanec
            {
                titul = zamestDto.titul,
                meno = zamestDto.meno,
                priezvisko = zamestDto.priezvisko,
                telefon = zamestDto.telefon,
                email = zamestDto.email
            };
        }
    }
}