using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FribergsCarRentals.DataAccess.Data
{
    public class CustomersRepository : ICustomersRepository
    {
        private FribergCarRentalsDbContext context;
        public CustomersRepository(FribergCarRentalsDbContext context)
        {
            this.context = context;
        }

        public Customer Get(int Id)
        {
            return context.Customers.Find(Id);
        }

        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }
        public void Delete(int Id)
        {

        }
        public void Save(Customer customer)
        {

        }

    }
}