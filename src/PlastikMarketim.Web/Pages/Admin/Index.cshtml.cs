using Microsoft.AspNetCore.Authorization;

namespace PlastikMarketim.Web.Pages.Admin
{
    [Authorize]
    public class IndexModel : PlastikMarketimAdminPageModel
    {
        public void OnGet()
        {
        }
    }
}