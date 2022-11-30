using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlastikMarketim.Web.Pages.Admin.Category
{
    [AutoValidateAntiforgeryToken]
    public class IndexModel : PageModel
    {
        public string NameFilter { get; set; }

        public void OnGet()
        {
        }
    }
}
