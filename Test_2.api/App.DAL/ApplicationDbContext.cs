using App.Entity.DTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication.ExtendedProtection;

namespace App.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public void CreateSchema(ModelBuilder builder)
        {
            OnModelCreating(builder);
        }

        public DbSet<CustomersDTO> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomersDTO>(b =>
            {
                b.ToTable("Customers");
					 b.HasKey(x => x.CustomerID);
				});
        }
    }
}

