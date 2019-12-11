using EfCoreFirstTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MigrationConsole
{
public class TestCompany1ContextFactory : IDesignTimeDbContextFactory<TestDbContext>
{
    private readonly IConfigurationRoot _configuration;

    public TestCompany1ContextFactory()
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
                             builder.MigrationsAssembly("MigrationConsole1");
                         });

        return new TestDbContext(optionBuilder.Options);
    }
}
}