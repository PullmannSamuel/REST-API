using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Oddelenie;
using api.Models;

namespace api.Interfaces
{
    public interface IOddelenieRepository
    {
        Task<List<Oddelenie>> GetAllAsync();
        Task<Oddelenie?> GetByIdAsync(int id);
        Task<Oddelenie> CreateAsync(Oddelenie oddelenieModel);
        Task<Oddelenie?> UpdateAsync(int projektId, int oddelenieId, UpdateOddelenieRequestDto oddelenieDto);
        Task<Oddelenie?> DeleteAsync(int id);
    }
}