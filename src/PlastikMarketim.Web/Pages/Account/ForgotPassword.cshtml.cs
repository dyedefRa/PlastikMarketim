using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace PlastikMarketim.Web.Pages.Account
{
    [AutoValidateAntiforgeryToken]
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public IdentityUserManager UserManager { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var userResult = await UserManager.FindByEmailAsync(Email);
            ////GeneratePasswordResetTokenAsync
            ////ResetPasswordAsync
            if (userResult == null)
            {
                ModelState.AddModelError("Email", "Kayýtlý kullanýcý bulunamadý.");
                return Page();
            }
            ModelState.AddModelError("Email", "Ýþlem baþarýsýz");
            return Page();
        }
    }
}