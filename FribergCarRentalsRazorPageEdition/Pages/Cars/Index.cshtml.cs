﻿using System;
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
        private readonly FribergCarRentalsRazorPageEdition.Data.FribergCarRentalsRazorPageEditionContext _context;
        private ICarsRepository _carsRepository;
        private ICustomersRepository _customersRepository;
        private IBookingsRepository _bookingsRepository;
        private IList<FribergsCarRentals.DataAccess.Data.Car> car = default!;

        public IndexModel(ICarsRepository carsRepository, ICustomersRepository customersRepository, IBookingsRepository bookingsRepository)
        {
            _carsRepository = carsRepository;
            _customersRepository = customersRepository;
            _bookingsRepository = bookingsRepository;
        }

        //public IndexModel(FribergCarRentalsRazorPageEdition.Data.FribergCarRentalsRazorPageEditionContext context)
        //{
        //    _context = context;
        //}

        public IList<Car> Car { get => car; set => car = value; }
        public async Task OnGetAsync()
        {
            //Car = (IList<Car>)await _context.Car.ToListAsync();
            //IEnumerable<FribergsCarRentals.DataAccess.Data.Car> Car = _carsRepository.GetAll();
            //var cars = _context.Car;
            Car = (IList<Car>)_carsRepository.GetAll();
        }
    }
}
