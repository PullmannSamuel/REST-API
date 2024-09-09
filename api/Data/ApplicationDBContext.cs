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

        public DbSet<Employee> employees { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Division> divisions { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Department> departments { get; set; }

    }
}