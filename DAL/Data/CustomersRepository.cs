using Microsoft.EntityFrameworkCore;

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
        public bool CustomerExists(int Id)
        {
            return context.Customers.Any(e => e.ID == Id);
        }
        public void Delete(Customer customer)
        {
            context.Remove(customer);
            context.SaveChanges();
        }
        public void SaveChanges(Customer customer)
        {
            context.Attach(customer).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Save(Customer customer)
        {
            context.Add(customer);
            context.SaveChanges();
        }

    }
}