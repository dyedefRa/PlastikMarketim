using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PlastikMarketim.Data
{
    /* This is used if database provider does't define
     * IPlastikMarketimDbSchemaMigrator implementation.
     */
    public class NullPlastikMarketimDbSchemaMigrator : IPlastikMarketimDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}