using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Zamestnanec> zamestnanci { get; set; }
        public DbSet<Firma> firmy { get; set; }
        public DbSet<Divizia> divizie { get; set; }
        public DbSet<Projekt> projekty { get; set; }
        public DbSet<Oddelenie> oddelenia { get; set; }

    }
}