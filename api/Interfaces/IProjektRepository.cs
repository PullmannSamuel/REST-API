using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Projekt;
using api.Models;

namespace api.Interfaces
{
    public interface IProjektRepository
    {
        Task<List<Projekt>> GetAllAsync();
        Task<Projekt?> GetByIdAsync(int id);
        Task<Projekt> CreateAsync(Projekt projektModel);
        Task<Projekt?> UpdateAsync(int diviziaId, int projektId, UpdateProjektRequestDto projektDto);
        Task<Projekt?> DeleteAsync(int id);
        Task<bool> ProjektExists(int id);
    }
}