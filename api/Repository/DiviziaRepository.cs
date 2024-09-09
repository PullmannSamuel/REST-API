using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Divizia;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DiviziaRepository : IDiviziaRepository
    {
        private readonly ApplicationDBContext context;
        public DiviziaRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Divizia> CreateAsync(Divizia diviziaModel)
        {
            var firma = await context.firmy.FirstOrDefaultAsync(f => f.id == diviziaModel.firmaId);
            if (firma == null)
            {
                return diviziaModel;
            }

            await context.divizie.AddAsync(diviziaModel);
            await context.SaveChangesAsync();

            firma.divizieId.Add(diviziaModel.id);
            await context.SaveChangesAsync();

            var divizia = await context.divizie
                .Include(x => x.veduciDivizie)
                .FirstOrDefaultAsync(x => x.id == diviziaModel.id);

            if (divizia != null) {
                return divizia;
            }

            return diviziaModel;
        }

        public async Task<Divizia?> DeleteAsync(int id)
        {
            var divizia = await context.divizie.FirstOrDefaultAsync(d => d.id == id);

            if (divizia == null) {
                return null;
            }

            context.divizie.Remove(divizia);
            await context.SaveChangesAsync();

            var firma = await context.firmy.FirstOrDefaultAsync(f => f.id == divizia.firmaId);
            
            if (firma != null) {
                firma.divizieId.Remove(divizia.id);
                await context.SaveChangesAsync();
            }
            
            return divizia;
        }

        public async Task<List<Divizia>> GetAllAsync()
        {
            return await context.divizie
                .Include(d => d.veduciDivizie).ToListAsync();
        }

        public async Task<Divizia?> GetByIdAsync(int id)
        {
            return await context.divizie
                .Include(d => d.veduciDivizie).FirstOrDefaultAsync(d => d.id == id);
        }

        public async Task<Divizia?> UpdateAsync(int firmaId, int diviziaId, UpdateDiviziaRequestDto diviziaDto)
        {
            var diviziaModel = await context.divizie
                .Include(d => d.veduciDivizie)
                .FirstOrDefaultAsync(d => d.id == diviziaId);

            if (diviziaModel == null) {
                return null;
            }

            if (diviziaModel.firmaId != firmaId) {
                var removeFromFirma = await context.firmy.FirstOrDefaultAsync(f => f.id == diviziaModel.firmaId);
                var addToFirma = await context.firmy.FirstOrDefaultAsync(f => f.id == firmaId);
                
                if (removeFromFirma != null) 
                {
                    removeFromFirma.divizieId.Remove(diviziaId);
                }

                if (addToFirma == null)
                {
                    return null;
                }
                addToFirma.divizieId.Add(diviziaId);
            }

            diviziaModel.nazov = diviziaDto.nazov;
            diviziaModel.kod = diviziaDto.kod;
            diviziaModel.veduciDivizieId = diviziaDto.veduciDivizieId;
            diviziaModel.firmaId = firmaId;

            await context.SaveChangesAsync();

            return diviziaModel;
        }

        public async Task<bool> DiviziaExists(int id)
        {
            return await context.divizie.AnyAsync(d => d.id == id);
        }
    }
}