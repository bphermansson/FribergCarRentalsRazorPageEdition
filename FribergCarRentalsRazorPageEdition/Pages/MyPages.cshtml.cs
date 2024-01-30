using FribergCarRentalsRazorPageEdition.Models;
using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorPageEdition.Pages
{
    public class MyPagesModel : PageModel
    {
        private IUsersRepository _usersRepository;
        [ViewData]
        public string LoginVisibility { get; set; }

        public MyPagesModel(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [BindProperty]
        public Login login { get; set; } = default!;

        public void OnGet(string loginVisibility)
        {
            //LoginVisible = loginVisible;
            //LoginVisibility = "none";
            LoginVisibility = "";
            var cook = Request.Cookies["loggedIn"];

        }
    }
}
