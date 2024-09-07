using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Zamestnanec;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ZamestnanecRepository : IZamestnanecRepository
    {
        private readonly ApplicationDBContext context;
        public ZamestnanecRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Zamestnanec> CreateAsync(Zamestnanec zamestModel)
        {
            await context.zamestnanci.AddAsync(zamestModel);
            await context.SaveChangesAsync();

            return zamestModel;
        }

        public async Task<Zamestnanec?> DeleteAsync(int id)
        {
            var zamestModel = await context.zamestnanci.FirstOrDefaultAsync(z => z.id == id);

            if (zamestModel == null) {
                return null;
            }

            context.zamestnanci.Remove(zamestModel);
            await context.SaveChangesAsync();

            return zamestModel;
        }

        public async Task<List<Zamestnanec>> GetAllAsync()
        {
            return await context.zamestnanci.ToListAsync();
        }

        public async Task<Zamestnanec?> GetByIdAsync(int id)
        {
            return await context.zamestnanci.FirstOrDefaultAsync(z => z.id == id);
        }

        public async Task<Zamestnanec?> UpdateAsync(int id, UpdateZamestnanecRequestDto zamestDto)
        {
            var zamestModel = await context.zamestnanci
                .FirstOrDefaultAsync(z => z.id == id);
            
            if (zamestModel == null) {
                return null;
            }

            zamestModel.titul = zamestDto.titul;
            zamestModel.meno = zamestDto.meno;
            zamestModel.priezvisko = zamestDto.priezvisko;
            zamestModel.telefon = zamestDto.telefon;
            zamestModel.email = zamestDto.email;

            await context.SaveChangesAsync();

            return zamestModel;
        }

        public async Task<bool> ZamestnanecExists(int id)
        {
            return await context.zamestnanci.AnyAsync(z => z.id == id);
        }
    }
}