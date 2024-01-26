using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentalsMVC.Models;
using FribergCarRentalsRazorPageEdition.Data;

namespace FribergCarRentalsRazorPageEdition.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly FribergCarRentalsRazorPageEdition.Data.FribergCarRentalsRazorPageEditionContext _context;

        public CreateModel(FribergCarRentalsRazorPageEdition.Data.FribergCarRentalsRazorPageEditionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
