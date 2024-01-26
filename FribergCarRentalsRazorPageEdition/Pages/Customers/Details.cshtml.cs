using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsMVC.Models;
using FribergCarRentalsRazorPageEdition.Data;
using FribergsCarRentals.DataAccess.Data;
using Car = FribergsCarRentals.DataAccess.Data.Car;

namespace FribergCarRentalsRazorPageEdition.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private ICarsRepository _carsRepository;
        //private IList<FribergsCarRentals.DataAccess.Data.Car> car = default!;

        //public IndexModel(ICarsRepository carsRepository)
        //{
        //    _carsRepository = carsRepository;
        //}

        //public IList<Car> Car { get => car; set => car = value; }
        //public async Task OnGetAsync()
        //{
        //    Car = (IList<Car>)_carsRepository.GetAll();
        //}


       // private readonly FribergCarRentalsRazorPageEdition.Data.FribergCarRentalsRazorPageEditionContext _context;

        public DetailsModel(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carsRepository.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }
    }
}
