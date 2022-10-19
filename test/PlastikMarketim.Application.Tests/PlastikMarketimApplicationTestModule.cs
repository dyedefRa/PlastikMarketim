using Volo.Abp.Modularity;

namespace PlastikMarketim
{
    [DependsOn(
        typeof(PlastikMarketimApplicationModule),
        typeof(PlastikMarketimDomainTestModule)
        )]
    public class PlastikMarketimApplicationTestModule : AbpModule
    {

    }
}