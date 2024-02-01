using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRentals.DataAccess.Data;

namespace FribergCarRentalsRazorPageEdition.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private IBookingsRepository _bookingsRepository;

        public EditModel(IBookingsRepository bookingsRepository)
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
            Booking = booking;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _bookingsRepository.SaveChanges(Booking);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Booking.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarExists(int? id)
        {
            return _bookingsRepository.BookingExists(id);
        }
    }
}
