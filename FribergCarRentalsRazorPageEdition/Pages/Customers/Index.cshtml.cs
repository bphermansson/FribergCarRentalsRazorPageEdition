using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;
using Custumer = FribergsCarRentals.DataAccess.Data.Customer;

namespace FribergCarRentalsRazorPageEdition.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private IList<FribergsCarRentals.DataAccess.Data.Customer> customer = default!;
        private ICustomersRepository _customersRepository;

        public IndexModel(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public IList<Customer> Customer { get => customer; set => customer = value; }
        public async Task OnGetAsync()
        {
            Customer = (IList<Customer>)_customersRepository.GetAll();
        }
    }
}
