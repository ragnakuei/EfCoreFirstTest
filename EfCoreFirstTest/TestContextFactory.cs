using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EfCoreFirstTest
{
    public class TestContextFactory : IDesignTimeDbContextFactory<TestDbContext>
    {
        private readonly IConfigurationRoot _configuration;

        public TestContextFactory()
        {
            _configuration = DiHelpers.DiFactory<IConfigurationRoot>();
        }

        public TestDbContext CreateDbContext(string[] args)
        {
            var connectionString = _configuration.GetConnectionString("TestCompany1");

            var optionBuilder = new DbContextOptionsBuilder<TestDbContext>()
               .UseSqlServer(connectionString
                           , builder =>
                             {
                                 builder.CommandTimeout(2400);
                                 builder.EnableRetryOnFailure(2);
                                 builder.MigrationsHistoryTable("_MigrationsHistory", "dbo");
                                 builder.MigrationsAssembly("EfCoreFirstTest");
                             });

            return new TestDbContext(optionBuilder.Options);
        }
    }
}