using CQRS_Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CQRS_Example.Infrastructure.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }


        // Optionally override OnModelCreating to further configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Custom configurations
        }
    }
}
