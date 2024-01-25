using Microsoft.EntityFrameworkCore;

namespace FribergsCarRentals.DataAccess.Data
{
    public class FribergCarRentalsDbContext:DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public FribergCarRentalsDbContext(DbContextOptions<FribergCarRentalsDbContext> options)
            :base(options) { }
    }
}
