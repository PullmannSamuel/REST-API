using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Zamestnanec;
using api.Models;

namespace api.Interfaces
{
    public interface IZamestnanecRepository
    {
        Task<List<Zamestnanec>> GetAllAsync();
        Task<Zamestnanec?> GetByIdAsync(int id);
        Task<Zamestnanec> CreateAsync(Zamestnanec zamestModel);
        Task<Zamestnanec?> UpdateAsync(int id, UpdateZamestnanecRequestDto zamestDto);
        Task<Zamestnanec?> DeleteAsync(int id);
        Task<bool> ZamestnanecExists(int id);
    }
}