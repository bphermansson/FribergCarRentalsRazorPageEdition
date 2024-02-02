using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;

namespace FribergCarRentalsRazorPageEdition.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private IBookingsRepository _bookingsRepository;
        [TempData]
        public string message { get; set; }

        public DeleteModel(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _bookingsRepository.Get(id);

            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var booking = _bookingsRepository.Get(id);
            if (booking != null)
            {
                message = "Booking deleted.";
                _bookingsRepository.Delete(booking);
            }
            return RedirectToPage("./Index");
        }
    }
}
