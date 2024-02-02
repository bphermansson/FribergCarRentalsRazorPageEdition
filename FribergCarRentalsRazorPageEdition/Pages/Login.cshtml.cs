using FribergCarRentalsRazorPageEdition.Models;
using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsRazorPageEdition.Pages
{

    public class MyPagesModel : PageModel
    {
        private IUsersRepository _usersRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        [Required]
        [BindProperty]
        public string Username { get; set; }
        [Required]
        [BindProperty]
        public string Password { get; set; }
        [ValidateNever]
        public string LoginVisibility { get; set; }
        public string LoggedInMessage { get; set; }
        [TempData]
        public string Message { get; set; }
        [TempData]
        public string SavedUsername { get; set; }


        public MyPagesModel(IUsersRepository usersRepository, IHttpContextAccessor httpContextAccessor)
        {
            _usersRepository = usersRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Login login { get; set; } = default!;

        public void OnGet()
        {
            LoginVisibility = "";
            LoggedInMessage = "None";
            var cook = Request.Cookies["loggedIn"];
            if (cook == "True")
            {
                LoginVisibility = "None";
                LoggedInMessage = "";
                Username = Request.Cookies["Username"];

            }
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userInDb = _usersRepository.GetByEmail(Username); 
            if (userInDb == null)
            {
                Message = "No such user, try again";
            }
            else
            {
                if (userInDb.Password == Password)
                {
                    Message = "Login ok";
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTimeOffset.UtcNow.AddHours(2);
                    httpContextAccessor.HttpContext.Response.Cookies.Append("loggedIn", "True", options);
                    httpContextAccessor.HttpContext.Response.Cookies.Append("Username", Username, options);
                    if(userInDb.IsAdmin == true)
                    {
                        httpContextAccessor.HttpContext.Response.Cookies.Append("IsAdmin", "True", options);

                    }
                }
                else
                {
                    Message = "Incorrect password";
                }
                SavedUsername = Username;
            }
            return RedirectToPage("./LoginConfirmation");
        }
    }
}
