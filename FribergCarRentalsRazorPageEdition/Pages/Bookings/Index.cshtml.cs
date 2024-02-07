using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace FribergCarRentalsRazorPageEdition.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private IList<Booking> booking = default!;
        private IBookingsRepository _bookingsRepository;
        private IUsersRepository _usersRepository;

        [TempData]
        public string Message { get; set; }

        public IndexModel(IBookingsRepository bookingsRepository, IUsersRepository usersRepository)
        {
            _bookingsRepository = bookingsRepository;
            _usersRepository = usersRepository;
        }

        public IList<Booking> Booking { get => booking; set => booking = value; }
        public async Task OnGetAsync(bool onlyUsers)
        {
            var Username = Request.Cookies[key: "Username"];
            //if (onlyUsers == true)
            //{
                // The code wont remove the isAdmin cookie on logout, thus this is a bad way to give permission to all bookings.
                // Check admin value in db instead.
                //var isAdmin = Request.Cookies["isAdmin"];
                //if (isAdmin != null)
                var userInDb = _usersRepository.GetByEmail(Username);
                if(userInDb != null)
                {
                    if (userInDb.IsAdmin == true && onlyUsers == false)
                    {
                        Booking = (IList<Booking>)_bookingsRepository.GetAll();
                    }
                    else
                    {
                        Booking = (IList<Booking>)_bookingsRepository.GetUserBookings(Username);
                    }
                }
                else
                {
                    Message = "No bookings, you are not logged in.";
                }
                
            //}
        }
    }
}
