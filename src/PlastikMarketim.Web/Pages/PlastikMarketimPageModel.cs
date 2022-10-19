using PlastikMarketim.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace PlastikMarketim.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class PlastikMarketimPageModel : AbpPageModel
    {
        protected PlastikMarketimPageModel()
        {
            LocalizationResourceType = typeof(PlastikMarketimResource);
        }
    }
}