using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergCarRentalsRazorPageEdition.Pages
{
    public class AdminModel : PageModel
    {
        private IUsersRepository _usersRepository;
        public AdminModel(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public bool isAdmin { get; set; }
        public string userName { get; set; }
        public void OnGet()
        {
            //isAdmin = Request.Cookies["isAdmin"];
            userName = Request.Cookies["Username"];
            var userInDb = _usersRepository.GetByEmail(userName);
            if(userInDb != null)
            {
                isAdmin = userInDb.IsAdmin;
            }
            else
            {
                isAdmin = false;
            }
        }
    }
}
