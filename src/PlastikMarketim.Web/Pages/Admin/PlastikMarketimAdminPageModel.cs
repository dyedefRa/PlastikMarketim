using PlastikMarketim.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace PlastikMarketim.Web.Pages.Admin
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class PlastikMarketimAdminPageModel : AbpPageModel
    {
        protected PlastikMarketimAdminPageModel()
        {
            LocalizationResourceType = typeof(PlastikMarketimResource);
        }
    }
}