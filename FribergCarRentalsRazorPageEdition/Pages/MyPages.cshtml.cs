using FribergCarRentalsRazorPageEdition.Models;
using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsRazorPageEdition.Pages
{

    public class MyPagesModel : PageModel
    {
        private IUsersRepository _usersRepository;

        //public Login Login { get; set; } = default!;
        [Required]
        [BindProperty]
        public string Username { get; set; }
        [Required]
        [BindProperty]
        public string Password { get; set; }

        [ValidateNever]
        public string LoginVisibility { get; set; }
        [TempData]
        public string Message { get; set; }

        
        public MyPagesModel(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Login login { get; set; } = default!;

        public void OnGet(string loginVisibility)
        {
            LoginVisibility = "";
            var cook = Request.Cookies["loggedIn"];

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
                Message = "No such user";

            }
            else
            {
                if (userInDb.Password == Password)
                {
                    Message = "Login ok";
                }
                else
                {
                    Message = "Incorrect password";
                }
            }

            return RedirectToPage("./MyPagesConfirmation");

        }
    }
}
