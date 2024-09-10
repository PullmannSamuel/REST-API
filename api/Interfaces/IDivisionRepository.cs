using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Division;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IDivisionRepository
    {
        Task<List<Division>> GetAllAsync(QueryObject query);
        Task<Division?> GetByIdAsync(int id);
        Task<Division> CreateAsync(Division divisionModel);
        Task<Division?> UpdateAsync(int companyId, int divisionId, UpdateDivisionRequestDto divisionDto);
        Task<Division?> DeleteAsync(int id);
        Task<bool> DivisionExists(int id);
    }
}