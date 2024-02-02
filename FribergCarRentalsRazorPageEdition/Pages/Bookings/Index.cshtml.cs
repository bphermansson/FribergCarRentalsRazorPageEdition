using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentalsRazorPageEdition.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private IList<Booking> booking = default!;
        private IBookingsRepository _bookingsRepository;
        //[TempData]
        //public string showAll { get; set; }

        public IndexModel(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public IList<Booking> Booking { get => booking; set => booking = value; }
        public async Task OnGetAsync(bool onlyUsers)
        {
            var Username = Request.Cookies[key: "Username"];

            if (onlyUsers==true)
            {
                var loggedInCookie = Request.Cookies["loggedIn"];
                var isAdmin = Request.Cookies["isAdmin"];
                ViewData["LoginName"] = Username;

                if (isAdmin != null)
                {
                    Booking = (IList<Booking>)_bookingsRepository.GetAll();
                }
            }
            else
            {
                Booking = (IList<Booking>)_bookingsRepository.GetUserBookings(Username);
            }



        }

    }
}
