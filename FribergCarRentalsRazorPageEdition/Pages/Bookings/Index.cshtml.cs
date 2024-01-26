using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;

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

        public IList<Booking> Booking { get => booking; set => booking = value; }
        public async Task OnGetAsync()
        {
            Booking = (IList<Booking>)_bookingsRepository.GetAll();
        }
    }
}
