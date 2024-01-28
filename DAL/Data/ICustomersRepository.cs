using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FribergsCarRentals.DataAccess.Data
{
    public interface ICustomersRepository
    {
        Customer Get(int Id);
        List<Customer> GetAll();
        public bool CustomerExists(int Id);
        void Delete(Customer Customer);
        public void SaveChanges(Customer Customer);
        public void Save(Customer Customer);

    }
}
