using Microsoft.EntityFrameworkCore;

namespace FribergsCarRentals.DataAccess.Data
{
    public class BookingsRepository : IBookingsRepository
    {
        private FribergCarRentalsDbContext context;
        public BookingsRepository(FribergCarRentalsDbContext context)
        {
            this.context = context;
        }

        public Booking Get(int Id)
        {
            return context.Bookings.Find(Id);
        }

        public List<Booking> GetAll()
        {
            return context.Bookings.ToList();
        }

        // Duplicate of save!
        public void Add(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
        }
        public bool BookingExists(int Id)
        {
            return true;
        }
        public void Delete(Booking booking)
        {
            context.Remove(booking);
            context.SaveChanges();
        }
        public void SaveChanges(Booking booking)
        {
            context.Attach(booking).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Save(Booking booking)
        {
            context.Add(booking);
            context.SaveChanges();
        }
    }
}