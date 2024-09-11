using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Company;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDBContext context;
        public CompanyRepository(ApplicationDBContext context) 
        {
            this.context = context;
        }

        public async Task<Company> CreateAsync(Company companyModel)
        {
            await context.companies.AddAsync(companyModel);
            await context.SaveChangesAsync();

            var company = await context.companies
                .Include(x => x.director)
                .FirstOrDefaultAsync(f => f.id == companyModel.id);
            
            if (company != null) {
                return company;
            }

            return companyModel; // In case Include fails, return original object
        }

        public async Task<Company?> DeleteAsync(int id)
        {
            var companyModel = await context.companies.FirstOrDefaultAsync(f => f.id == id);

            if (companyModel == null) {
                return null;
            }

            context.companies.Remove(companyModel);
            await context.SaveChangesAsync();

            return companyModel;
        }
        
        public async Task<List<Company>> GetAllAsync(QueryObject query)
        {
            var companies = context.companies
                .Include(f => f.director).AsQueryable();

            // Apply filters based on query parameters
            if (!string.IsNullOrWhiteSpace(query.name)) {
                companies = companies.Where(c => c.name.Contains(query.name));
            }

            if (!string.IsNullOrWhiteSpace(query.code)) {
                companies = companies.Where(c => c.code.Contains(query.code));
            }
                
            return await companies.ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await context.companies
                .Include(f => f.director).FirstOrDefaultAsync(f => f.id == id);
        }

        public async Task<Company?> UpdateAsync(int id, UpdateCompanyRequestDto companyDto)
        {
            var companyModel = await context.companies
                .Include(x => x.director)
                .FirstOrDefaultAsync(f => f.id == id);

            if (companyModel == null) {
                return null;
            }

            // Update the company fields with new values
            companyModel.name = companyDto.name;
            companyModel.code = companyDto.code;
            companyModel.directorId = companyDto.directorId;

            await context.SaveChangesAsync();

            return companyModel;
        }

        public async Task<bool> CompanyExists(int id)
        {
            return await context.companies.AnyAsync(f => f.id == id);
        }
    }
}