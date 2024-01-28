using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
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