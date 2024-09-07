using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Firma;
using api.Migrations;
using api.Models;

namespace api.Interfaces
{
    public interface IFirmaRepository
    {
        Task<List<Firma>> GetAllAsync();
        Task<Firma?> GetByIdAsync(int id);
        Task<Firma> CreateAsync(Firma firmaModel);
        Task<Firma?> UpdateAsync(int id, UpdateFirmaRequestDto firmaDto);
        Task<Firma?> DeleteAsync(int id);
        Task<bool> FirmaExists(int id);
    }
}