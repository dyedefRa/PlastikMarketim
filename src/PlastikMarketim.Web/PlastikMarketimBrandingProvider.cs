using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace PlastikMarketim.Web
{
    [Dependency(ReplaceServices = true)]
    public class PlastikMarketimBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "PlastikMarketim";
    }
}
