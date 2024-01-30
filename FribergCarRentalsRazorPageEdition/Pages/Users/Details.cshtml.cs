using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;

namespace FribergCarRentalsRazorPageEdition.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private IUsersRepository _customersRepository;

        public DetailsModel(IUsersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public User Customer { get; set; } = default!;

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
    }
}
