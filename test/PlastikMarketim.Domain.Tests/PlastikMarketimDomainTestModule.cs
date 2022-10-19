using PlastikMarketim.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace PlastikMarketim
{
    [DependsOn(
        typeof(PlastikMarketimEntityFrameworkCoreTestModule)
        )]
    public class PlastikMarketimDomainTestModule : AbpModule
    {

    }
}