using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Firma;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class FirmaRepository : IFirmaRepository
    {
        private readonly ApplicationDBContext context;
        public FirmaRepository(ApplicationDBContext context) 
        {
            this.context = context;
        }

        public async Task<Firma> CreateAsync(Firma firmaModel)
        {
            await context.firmy.AddAsync(firmaModel);
            await context.SaveChangesAsync();

            var firma = await context.firmy
                .Include(x => x.riaditel)
                .FirstOrDefaultAsync(f => f.id == firmaModel.id);
            
            if (firma != null) {
                return firma;
            }

            return firmaModel;
        }

        public async Task<Firma?> DeleteAsync(int id)
        {
            var firmaModel = await context.firmy.FirstOrDefaultAsync(f => f.id == id);

            if (firmaModel == null) {
                return null;
            }

            context.firmy.Remove(firmaModel);
            await context.SaveChangesAsync();

            return firmaModel;
        }
        
        public async Task<List<Firma>> GetAllAsync()
        {
            return await context.firmy
                .Include(f => f.riaditel).ToListAsync();
        }

        public async Task<Firma?> GetByIdAsync(int id)
        {
            return await context.firmy
                .Include(f => f.riaditel).FirstOrDefaultAsync(f => f.id == id);
        }

        public async Task<Firma?> UpdateAsync(int id, UpdateFirmaRequestDto firmaDto)
        {
            var firmaModel = await context.firmy
                .Include(x => x.riaditel)
                .FirstOrDefaultAsync(f => f.id == id);

            if (firmaModel == null) {
                return null;
            }

            firmaModel.nazov = firmaDto.nazov;
            firmaModel.kod = firmaDto.kod;
            firmaModel.riaditelId = firmaDto.riaditelId;

            await context.SaveChangesAsync();

            return firmaModel;
        }

        public async Task<bool> FirmaExists(int id)
        {
            return await context.firmy.AnyAsync(f => f.id == id);
        }
    }
}