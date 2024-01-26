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
        void Delete(int Id);
    }
}
