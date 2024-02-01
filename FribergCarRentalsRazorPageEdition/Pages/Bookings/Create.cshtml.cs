﻿using Microsoft.AspNetCore.Mvc;
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
        public int User {  get; set; }
        [BindProperty, DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        [BindProperty]
        public string Make { get; set; }
        [BindProperty]
        public string Model { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateOnly Date {  get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateOnly DateTomorrow { get; set; }
        public string BookingFormVisibility { get; set; }
        public string LoginNoticeVisibility { get; set; }

        [TempData]
        public string Message { get; set; }

        public CreateModel(IBookingsRepository bookingsRepository, IUsersRepository customersRepository)
        {
            _bookingsRepository = bookingsRepository;
            _customersRepository = customersRepository;
        }

        public IActionResult OnGet(int id, int customer, string make, string model)
        {
            var loggedInCookie = Request.Cookies["loggedIn"];
            var Username = Request.Cookies["Username"];
            LoginNoticeVisibility = "none";

            if (loggedInCookie != "True")
            {
                LoginNoticeVisibility = "";
                BookingFormVisibility = "none";


            }
            else
            {
                Id = id;
                User = customer;
                UserEmail = Username;
                Make = make;
                Model = model;

                // Remove time , keep date
                Date = DateOnly.FromDateTime(DateTime.Now);
                DateTomorrow = Date.AddDays(1);
            }
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
            
            Message = $"Customer email: {UserEmail}\nCar make&model: {Make} {Model}\nFrom: {Booking.StartDate} to {Booking.StopDate}";
            

            _bookingsRepository.Add(Booking);
            return RedirectToPage("./Confirmation");
        }
    }
}
