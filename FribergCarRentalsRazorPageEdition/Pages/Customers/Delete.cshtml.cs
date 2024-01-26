using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;
using Car = FribergsCarRentals.DataAccess.Data.Car;

namespace FribergCarRentalsRazorPageEdition.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private ICustomersRepository _customersRepository;

        public DeleteModel(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customersRepository.Get(id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = _customersRepository.Get(id);
            if (car != null)
            {
                _customersRepository.Delete(id);
            }
            return RedirectToPage("./Index");
        }
    }
}
