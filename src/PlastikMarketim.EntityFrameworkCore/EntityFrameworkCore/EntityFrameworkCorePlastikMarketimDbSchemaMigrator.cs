using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlastikMarketim.Data;
using Volo.Abp.DependencyInjection;

namespace PlastikMarketim.EntityFrameworkCore
{
    public class EntityFrameworkCorePlastikMarketimDbSchemaMigrator
        : IPlastikMarketimDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCorePlastikMarketimDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the PlastikMarketimDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<PlastikMarketimDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
