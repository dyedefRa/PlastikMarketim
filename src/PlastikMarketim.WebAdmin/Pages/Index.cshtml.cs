using Microsoft.AspNetCore.Authorization;

namespace PlastikMarketim.Web.Pages
{
    [Authorize]
    public class IndexModel : PlastikMarketimPageModel
    {
        public void OnGet()
        {
        }
    }
}