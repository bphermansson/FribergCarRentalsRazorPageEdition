using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FribergsCarRentals.DataAccess.Data
{
    public interface IBookingsRepository
    {
        Booking Get(int Id);
        List<Booking> GetAll();
        void Add(Booking booking);

    }
}
