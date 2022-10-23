using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlastikMarketim.Web.Pages.Account
{
    public class ChangePasswordResultModel : PageModel
    {
        public bool Result { get; set; }
        public void OnGet(bool result)
        {
            Result = result;
        }
    }
}
