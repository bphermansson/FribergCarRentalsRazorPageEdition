using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsMVC.Models;

namespace FribergCarRentalsRazorPageEdition.Data
{
    public class FribergCarRentalsRazorPageEditionContext : DbContext
    {
        public FribergCarRentalsRazorPageEditionContext (DbContextOptions<FribergCarRentalsRazorPageEditionContext> options)
            : base(options)
        {
        }

        public DbSet<FribergCarRentalsMVC.Models.Car> Car { get; set; } = default!;
    }
}
