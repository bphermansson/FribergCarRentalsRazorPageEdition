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

namespace FribergCarRentalsRazorPageEdition.Pages.Cars
{
    public class IndexModel : PageModel
    {
        //private readonly FribergCarRentalsRazorPageEdition.Data.FribergCarRentalsRazorPageEditionContext _context;
        private ICarsRepository _carsRepository;
        //private ICustomersRepository _customersRepository;
        //private IBookingsRepository _bookingsRepository;
        private IList<FribergsCarRentals.DataAccess.Data.Car> car = default!;

        //public IndexModel(ICarsRepository carsRepository, ICustomersRepository customersRepository, IBookingsRepository bookingsRepository)
        public IndexModel(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
            //_customersRepository = customersRepository;
            //_bookingsRepository = bookingsRepository;
        }

        public IList<Car> Car { get => car; set => car = value; }
        public string isAdmin { get; set; }

        public async Task OnGetAsync()
        {
            isAdmin = Request.Cookies["isAdmin"];
            Car = (IList<Car>)_carsRepository.GetAll();
        }
    }
}
