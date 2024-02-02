using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentalsRazorPageEdition.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private IList<Booking> booking = default!;
        private IBookingsRepository _bookingsRepository;
        [TempData]
        public string showAll { get; set; }

        public IndexModel(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public IList<Booking> Booking { get => booking; set => booking = value; }
        public async Task OnGetAsync(bool onlyUsers)
        {
            // if admin, showAll = true
            // Use this to hide edit button



            if(onlyUsers==true)
            {
                var loggedInCookie = Request.Cookies["loggedIn"];
                var Username = Request.Cookies["Username"];
                if (loggedInCookie != null)
                {
                    Booking = (IList<Booking>)_bookingsRepository.GetUserBookings(Username);

                }
            }
            else
            {
                // As onlyUsers is false here, we assume it is admin who request the page
                Booking = (IList<Booking>)_bookingsRepository.GetAll();
            }



        }

    }
}
