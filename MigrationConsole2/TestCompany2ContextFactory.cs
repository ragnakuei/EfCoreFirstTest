using EfCoreFirstTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MigrationConsole
{
public class TestCompany2ContextFactory : IDesignTimeDbContextFactory<TestDbContext>
{
    private readonly IConfigurationRoot _configuration;

    public TestCompany2ContextFactory()
    {
        _configuration = DiHelpers.DiFactory<IConfigurationRoot>();
    }

    public TestDbContext CreateDbContext(string[] args)
    {
        var connectionString = _configuration.GetConnectionString("TestCompany2");

        var optionBuilder = new DbContextOptionsBuilder<TestDbContext>()
           .UseSqlServer(connectionString
                       , builder =>
                         {
                             builder.CommandTimeout(2400);
                             builder.EnableRetryOnFailure(2);
                             builder.MigrationsHistoryTable("_MigrationsHistory", "dbo");
                             builder.MigrationsAssembly("MigrationConsole2");
                         });

        return new TestDbContext(optionBuilder.Options);
    }
}
}