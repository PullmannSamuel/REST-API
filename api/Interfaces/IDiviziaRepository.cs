using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Divizia;
using api.Models;

namespace api.Interfaces
{
    public interface IDiviziaRepository
    {
        Task<List<Divizia>> GetAllAsync();
        Task<Divizia?> GetByIdAsync(int id);
        Task<Divizia> CreateAsync(Divizia diviziaModel);
        Task<Divizia?> UpdateAsync(int firmaId, int diviziaId, UpdateDiviziaRequestDto diviziaDto);
        Task<Divizia?> DeleteAsync(int id);
        Task<bool> DiviziaExists(int id);
    }
}