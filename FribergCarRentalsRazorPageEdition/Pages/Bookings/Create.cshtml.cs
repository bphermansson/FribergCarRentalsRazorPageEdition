using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;

namespace FribergCarRentalsRazorPageEdition.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private IBookingsRepository _bookingsRepository;

        public CreateModel(BookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _bookingsRepository.Add(Booking);
            return RedirectToPage("./Index");
        }
    }
}
