using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsMVC.Models;
using FribergCarRentalsRazorPageEdition.Data;
using FribergsCarRentals.DataAccess.Data;


namespace FribergCarRentalsRazorPageEdition.Pages.Customers
{
    public class EditModel : PageModel
    {
        private IUsersRepository _customersRepository;

        public EditModel(IUsersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [BindProperty]
        public User Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customersRepository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
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
                _customersRepository.SaveChanges(Customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Customer.ID))
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

        private bool CarExists(int id)
        {
            return _customersRepository.CustomerExists(id);
        }
    }
}
