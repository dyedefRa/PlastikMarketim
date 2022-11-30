using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlastikMarketim.Web.Pages.Admin.ContactForm
{
    public class IndexModel : PageModel
    {
        public string FullNameFilter { get; set; }
        public string EmailFilter { get; set; }

        public void OnGet()
        {
        }
    }
}
