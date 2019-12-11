using EfCoreFirstTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreFirstTest
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestDbContext).Assembly
                                                       , t => t.Namespace?.StartsWith("EF.EntityTypeConfigurations") == true);

            modelBuilder.Entity<Customer>().ToTable("Customers");
        }
    }
}