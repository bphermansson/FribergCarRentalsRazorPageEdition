using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace FribergCarRentalsRazorPageEdition.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        [TempData]
        public string Message { get; set; }

        public LogOutModel(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            httpContextAccessor.HttpContext.Response.Cookies.Delete("loggedIn");
            Message = "You are logged out";
            return RedirectToPage("./LoginConfirmation");
        }
    }
}