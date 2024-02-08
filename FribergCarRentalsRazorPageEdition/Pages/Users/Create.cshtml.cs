using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentalsMVC.Models;

namespace FribergCarRentalsRazorPageEdition.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private IUsersRepository _customersRepository;

        public CreateModel(IUsersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User Customer { get; set; } = default!;
        [TempData]
        public string Message { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _customersRepository.Save(Customer);
            Message = "New user created";
            return RedirectToPage("./Confirmation");
        }
    }
}
