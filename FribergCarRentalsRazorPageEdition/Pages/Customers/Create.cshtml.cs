using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergCarRentalsMVC.Models;

namespace FribergCarRentalsRazorPageEdition.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private ICustomersRepository _customersRepository;

        public CreateModel(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _customersRepository.Save(Customer);
            return RedirectToPage("./Index");
        }
    }
}
