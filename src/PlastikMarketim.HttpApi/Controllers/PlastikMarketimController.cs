using PlastikMarketim.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PlastikMarketim.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class PlastikMarketimController : AbpController
    {
        protected PlastikMarketimController()
        {
            LocalizationResource = typeof(PlastikMarketimResource);
        }
    }
}