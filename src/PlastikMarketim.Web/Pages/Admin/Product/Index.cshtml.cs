using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlastikMarketim.Web.Pages.Admin.Product
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
