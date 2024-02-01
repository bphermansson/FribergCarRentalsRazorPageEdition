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
        private IUsersRepository _customersRepository;

        [ViewData]
        public int Id { get; set; }
        public int Customer {  get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateOnly Date {  get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateOnly DateTomorrow { get; set; }

        public CreateModel(IBookingsRepository bookingsRepository, IUsersRepository customersRepository)
        {
            _bookingsRepository = bookingsRepository;
            _customersRepository = customersRepository;

        }

        public IActionResult OnGet(int id, int customer, string make, string model)
        {
            var logginInCookie = Request.Cookies["loggedIn"];
            if (logginInCookie != "True")
            {
                RedirectToPage("./MyPages");

            }

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

            // Is the user registered?



            _bookingsRepository.Add(Booking);
            return RedirectToPage("./Confirmation");
        }
    }
}
