using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net;

namespace FribergCarRentalsRazorPageEdition.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        
        [TempData]
        public string Message { get; set; }
        public string Username { get; set; }

        public LogOutModel(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {
            Username = Request.Cookies["Username"];
        }
        public async Task<IActionResult> OnPostAsync()
        {
           httpContextAccessor.HttpContext.Response.Cookies.Delete("loggedIn");
           httpContextAccessor.HttpContext.Response.Cookies.Delete("Username");
           httpContextAccessor.HttpContext.Response.Cookies.Delete("isAdmin");
           Message = "You are logged out";
           return RedirectToPage("./LoginConfirmation");
        }
    }
}