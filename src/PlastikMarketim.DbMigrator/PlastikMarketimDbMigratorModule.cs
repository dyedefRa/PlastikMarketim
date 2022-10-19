using PlastikMarketim.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace PlastikMarketim.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(PlastikMarketimEntityFrameworkCoreModule),
        typeof(PlastikMarketimApplicationContractsModule)
        )]
    public class PlastikMarketimDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
