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
        public string Email { get; set; }
        [Required]
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Referer { get; set; }
        [BindProperty]
        public User UserModel{ get; set; }
        public  User User { get; set; }
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

        public void OnGet(string referer)
        {
            LoginVisibility = "";
            LoggedInMessage = "None";
            var cook = Request.Cookies["loggedIn"];
            if (cook == "True")
            {
                LoginVisibility = "None";
                LoggedInMessage = "";
                Email = Request.Cookies["Username"];
                Message = "You are logged in.";
            }
            else if(referer == "login")
            {
                TempData["url"] = "./Index";
            }
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostLoginAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var userInDb = _usersRepository.GetByEmail(Email); 
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
                    httpContextAccessor.HttpContext.Response.Cookies.Append("Username", Email, options);
                    if(userInDb.IsAdmin == true)
                    {
                        httpContextAccessor.HttpContext.Response.Cookies.Append("IsAdmin", "True", options);
                    }
                    string Url="", Make="", Model="";
                    if (TempData.ContainsKey("url"))
                        Url = TempData["url"].ToString();
                        Make = TempData["make"].ToString();
                        Model = TempData["model"].ToString();
                    return RedirectToPage(Url, new { make = Make, model = Model });
                }
                else
                {
                    Message = "Incorrect password";
                }
                SavedUsername = Email;
            }

            return RedirectToPage("./LoginConfirmation");
        }
        public async Task<IActionResult> OnPostRegisterAsync()
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _usersRepository.Save(UserModel);

            // Also auto login the new user
            var userInDb = _usersRepository.GetByEmail(UserModel.Email);
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.UtcNow.AddHours(2);
            httpContextAccessor.HttpContext.Response.Cookies.Append("loggedIn", "True", options);
            httpContextAccessor.HttpContext.Response.Cookies.Append("Username", UserModel.Email, options);
            if (userInDb.IsAdmin == true)
            {
                httpContextAccessor.HttpContext.Response.Cookies.Append("IsAdmin", "True", options);
            }
            string Url = "", Make = "", Model = "";
            if (TempData.ContainsKey("url"))
                Url = TempData["url"].ToString();
            Make = TempData["make"].ToString();
            Model = TempData["model"].ToString();
            return RedirectToPage(Url, new { make = Make, model = Model });
        }
    }
}
