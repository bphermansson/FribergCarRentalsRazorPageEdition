using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergCarRentalsRazorPageEdition.Pages
{
    public class AdminModel : PageModel
    {
        public string isAdmin { get; set; }
        public string userName { get; set; }
        public void OnGet()
        {
            isAdmin = Request.Cookies["isAdmin"];
            userName = Request.Cookies["Username"];

        }
    }
}
