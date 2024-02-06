using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentalsRazorPageEdition.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private IList<Booking> booking = default!;
        private IBookingsRepository _bookingsRepository;

        public IndexModel(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

       // [TempData]
        public IList<Booking> Booking { get => booking; set => booking = value; }
        public async Task OnGetAsync(bool onlyUsers)
        {
            var Username = Request.Cookies[key: "Username"];

            if (onlyUsers == true)
            {
                var isAdmin = Request.Cookies["isAdmin"];

                if (isAdmin != null)
                {
                    Booking = (IList<Booking>)_bookingsRepository.GetAll();
                }
                else
                {
                    Booking = (IList<Booking>)_bookingsRepository.GetUserBookings(Username);
                }
            }
        }
    }
}
