using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;
using Booking = FribergsCarRentals.DataAccess.Data.Booking;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsRazorPageEdition.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private IBookingsRepository _bookingsRepository;

        [ViewData]
        public int Id { get; set; }
        public int Customer {  get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateOnly Date {  get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateOnly DateTomorrow { get; set; }

        public CreateModel(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public IActionResult OnGet(int id, int customer, string make, string model)
        {
            Id = id;
            Customer = customer;
            Make = make;
            Model = model;

            // Remove time , keep date
            Date = DateOnly.FromDateTime(DateTime.Now);
            DateTomorrow = Date.AddDays(1);
            
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
