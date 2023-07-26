using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace TestUnaDesk.Data;

public class TestUnaDeskEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public TestUnaDeskEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the TestUnaDeskDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<TestUnaDeskDbContext>()
            .Database
            .MigrateAsync();
    }
}
