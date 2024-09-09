using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Oddelenie;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class OddelenieRepository : IOddelenieRepository
    {
        private readonly ApplicationDBContext context;
        public OddelenieRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Oddelenie> CreateAsync(Oddelenie oddelenieModel)
        {
            var projekt = await context.projekty.FirstOrDefaultAsync(p => p.id == oddelenieModel.projektId);

            if (projekt == null) {
                return oddelenieModel;
            }

            await context.oddelenia.AddAsync(oddelenieModel);
            await context.SaveChangesAsync();

            projekt.oddeleniaId.Add(oddelenieModel.id);
            await context.SaveChangesAsync();

            var oddelenie = await context.oddelenia
                .Include(x => x.veduciOddelenia)
                .FirstOrDefaultAsync(x => x.id == oddelenieModel.id);

            if (oddelenie != null) {
                return oddelenie;
            }

            return oddelenieModel;
        }

        public async Task<Oddelenie?> DeleteAsync(int id)
        {
            var oddelenie = await context.oddelenia.FirstOrDefaultAsync(o => o.id == id);

            if (oddelenie == null) {
                return null;
            }

            context.oddelenia.Remove(oddelenie);
            await context.SaveChangesAsync();

            var projekt = await context.projekty.FirstOrDefaultAsync(p => p.id == oddelenie.projektId);

            if (projekt != null) {
                projekt.oddeleniaId.Remove(oddelenie.id);
                await context.SaveChangesAsync();
            }

            return oddelenie;
        }

        public async Task<List<Oddelenie>> GetAllAsync()
        {
            return await context.oddelenia
                .Include(o => o.veduciOddelenia).ToListAsync();
        }

        public async Task<Oddelenie?> GetByIdAsync(int id)
        {
            return await context.oddelenia
                .Include(o => o.veduciOddelenia).FirstOrDefaultAsync(o => o.id == id);
        }

        public async Task<Oddelenie?> UpdateAsync(int projektId, int oddelenieId, UpdateOddelenieRequestDto oddelenieDto)
        {
            var oddelenieModel = await context.oddelenia
                .Include(o => o.veduciOddelenia)
                .FirstOrDefaultAsync(o => o.id == oddelenieId);

            if (oddelenieModel == null) {
                return null;
            }

            if (oddelenieModel.projektId != projektId) {
                var removeFromProjekt = await context.projekty.FirstOrDefaultAsync(p => p.id == oddelenieModel.projektId);
                var addToProjekt = await context.projekty.FirstOrDefaultAsync(p => p.id == projektId);

                if (removeFromProjekt != null) {
                    removeFromProjekt.oddeleniaId.Remove(oddelenieId);
                }

                if (addToProjekt == null) {
                    return null;
                }

                addToProjekt.oddeleniaId.Add(oddelenieId);
            }

            oddelenieModel.nazov = oddelenieDto.nazov;
            oddelenieModel.kod = oddelenieDto.kod;
            oddelenieModel.veduciOddeleniaId = oddelenieDto.veduciOddeleniaId;
            oddelenieModel.projektId = projektId;

            await context.SaveChangesAsync();

            return oddelenieModel;
        }
    }
}