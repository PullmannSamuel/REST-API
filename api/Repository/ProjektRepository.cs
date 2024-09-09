using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Projekt;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProjektRepository : IProjektRepository
    {
        private readonly ApplicationDBContext context;
        public ProjektRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Projekt> CreateAsync(Projekt projektModel)
        {
            var divizia = await context.divizie.FirstOrDefaultAsync(d => d.id == projektModel.diviziaId);
            
            if (divizia == null) {
                return projektModel;
            }

            await context.projekty.AddAsync(projektModel);
            await context.SaveChangesAsync();

            divizia.projektyId.Add(projektModel.id);
            await context.SaveChangesAsync();

            var projekt = await context.projekty
                .Include(x => x.veduciProjektu)
                .FirstOrDefaultAsync(x => x.id == projektModel.id);

            if (projekt != null) {
                return projekt;
            }

            return projektModel;
        }

        public async Task<Projekt?> DeleteAsync(int id)
        {
            var projekt = await context.projekty.FirstOrDefaultAsync(p => p.id == id);

            if (projekt == null) {
                return null;
            }

            context.projekty.Remove(projekt);
            await context.SaveChangesAsync();

            var divizia = await context.divizie.FirstOrDefaultAsync(d => d.id == projekt.diviziaId);

            if (divizia != null) {
                divizia.projektyId.Remove(projekt.id);
                await context.SaveChangesAsync();
            }

            return projekt;
        }

        public async Task<List<Projekt>> GetAllAsync()
        {
            return await context.projekty
                .Include(p => p.veduciProjektu).ToListAsync();
        }

        public async Task<Projekt?> GetByIdAsync(int id)
        {
            return await context.projekty
                .Include(p => p.veduciProjektu).FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Projekt?> UpdateAsync(int diviziaId, int projektId, UpdateProjektRequestDto projektDto)
        {
            var projektModel = await context.projekty
                .Include(p => p.veduciProjektu)
                .FirstOrDefaultAsync(p => p.id == projektId);

            if (projektModel == null) {
                return null;
            }

            if (projektModel.diviziaId != diviziaId) {
                var removeFromDivizia = await context.divizie.FirstOrDefaultAsync(d => d.id == projektModel.diviziaId);
                var addToDivizia = await context.divizie.FirstOrDefaultAsync(d => d.id == diviziaId);

                if (removeFromDivizia != null) {
                    removeFromDivizia.projektyId.Remove(projektId);
                }

                if (addToDivizia == null) {
                    return null;
                }

                addToDivizia.projektyId.Add(projektId);
            }

            projektModel.nazov = projektDto.nazov;
            projektModel.kod = projektDto.kod;
            projektModel.veduciProjektuId = projektDto.veduciProjektuId;
            projektModel.diviziaId = diviziaId;

            await context.SaveChangesAsync();

            return projektModel;
        }

        public async Task<bool> ProjektExists(int id)
        {
            return await context.projekty.AnyAsync(p => p.id == id);
        }
    }
}