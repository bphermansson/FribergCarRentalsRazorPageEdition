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
        private ICarsRepository _carsRepository;
        private IUsersRepository _usersRepository;
        private IList<FribergsCarRentals.DataAccess.Data.Car> car = default!;
        public IndexModel(ICarsRepository carsRepository, IUsersRepository usersRepository)
        {
            _carsRepository = carsRepository;
            _usersRepository = usersRepository;
        }

        public IList<Car> Car { get => car; set => car = value; }
        public bool isAdmin { get; set; }

        public async Task OnGetAsync()
        {
            var Username =  Request.Cookies["Username"];
            var userInDb = _usersRepository.GetByEmail(Username);
            if (userInDb != null)
            {
                isAdmin = userInDb.IsAdmin;
            }
            //isAdmin = Request.Cookies["isAdmin"];
            Car = (IList<Car>)_carsRepository.GetAll();
        }
    }
}
