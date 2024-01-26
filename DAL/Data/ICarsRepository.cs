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
        public bool CarExists(int Id);
        public void Delete(Car Car);
        public void Save(Car Car);
    }
}
