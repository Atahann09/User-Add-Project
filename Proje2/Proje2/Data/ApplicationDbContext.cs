using Microsoft.EntityFrameworkCore;
using Proje2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje2.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password = ata123;");
        }

        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
