using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;
using Custumer = FribergsCarRentals.DataAccess.Data.User;

namespace FribergCarRentalsRazorPageEdition.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private IList<FribergsCarRentals.DataAccess.Data.User> user = default!;
        private IUsersRepository _usersRepository;

        public IndexModel(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IList<User> Customer { get => user; set => user = value; }
        public async Task OnGetAsync()
        {
            Customer = (IList<User>)_usersRepository.GetAll();
        }
    }
}
