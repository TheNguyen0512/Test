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

        public DbSet<CustomerDTO> Customer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDTO>(b =>
            {
                b.ToTable("Customer");
					 b.HasKey(x => x.CustomerID);
				});
        }
    }
}

