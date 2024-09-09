using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Division;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DivisionRepository : IDivisionRepository
    {
        private readonly ApplicationDBContext context;
        public DivisionRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Division> CreateAsync(Division divisionModel)
        {
            var company = await context.companies.FirstOrDefaultAsync(f => f.id == divisionModel.companyId);
            if (company == null)
            {
                return divisionModel;
            }

            await context.divisions.AddAsync(divisionModel);
            await context.SaveChangesAsync();

            company.divisionsId.Add(divisionModel.id);
            await context.SaveChangesAsync();

            var division = await context.divisions
                .Include(x => x.headOfDivision)
                .FirstOrDefaultAsync(x => x.id == divisionModel.id);

            if (division != null) {
                return division;
            }

            return divisionModel;
        }

        public async Task<Division?> DeleteAsync(int id)
        {
            var division = await context.divisions.FirstOrDefaultAsync(d => d.id == id);

            if (division == null) {
                return null;
            }

            context.divisions.Remove(division);
            await context.SaveChangesAsync();

            var company = await context.companies.FirstOrDefaultAsync(f => f.id == division.companyId);
            
            if (company != null) {
                company.divisionsId.Remove(division.id);
                await context.SaveChangesAsync();
            }
            
            return division;
        }

        public async Task<List<Division>> GetAllAsync()
        {
            return await context.divisions
                .Include(d => d.headOfDivision).ToListAsync();
        }

        public async Task<Division?> GetByIdAsync(int id)
        {
            return await context.divisions
                .Include(d => d.headOfDivision).FirstOrDefaultAsync(d => d.id == id);
        }

        public async Task<Division?> UpdateAsync(int companyId, int divisionId, UpdateDivisionRequestDto divisionDto)
        {
            var divisionModel = await context.divisions
                .Include(d => d.headOfDivision)
                .FirstOrDefaultAsync(d => d.id == divisionId);

            if (divisionModel == null) {
                return null;
            }

            if (divisionModel.companyId != companyId) {
                var removeFromCompany = await context.companies.FirstOrDefaultAsync(f => f.id == divisionModel.companyId);
                var addToCompany = await context.companies.FirstOrDefaultAsync(f => f.id == companyId);
                
                if (removeFromCompany != null) 
                {
                    removeFromCompany.divisionsId.Remove(divisionId);
                }

                if (addToCompany == null)
                {
                    return null;
                }
                addToCompany.divisionsId.Add(divisionId);
            }

            divisionModel.name = divisionDto.name;
            divisionModel.code = divisionDto.code;
            divisionModel.headOfDivisionId = divisionDto.headOfDivisionId;
            divisionModel.companyId = companyId;

            await context.SaveChangesAsync();

            return divisionModel;
        }

        public async Task<bool> DivisionExists(int id)
        {
            return await context.divisions.AnyAsync(d => d.id == id);
        }
    }
}