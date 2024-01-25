using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FribergsCarRentals.DataAccess.Data
{
    public interface ICarsRepository
    {
        Car Get(int Id);
        IEnumerable<Car> GetAll();
    }
}
