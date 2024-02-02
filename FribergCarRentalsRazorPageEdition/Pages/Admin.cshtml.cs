using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
