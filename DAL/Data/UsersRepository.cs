using Microsoft.EntityFrameworkCore;

namespace FribergsCarRentals.DataAccess.Data
{
    public class UsersRepository : IUsersRepository
    {
        private FribergCarRentalsDbContext context;
        public UsersRepository(FribergCarRentalsDbContext context)
        {
            this.context = context;
        }

        public User Get(int Id)
        {
            return context.Users.Find(Id);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }
        public bool CustomerExists(int Id)
        {
            return context.Users.Any(e => e.ID == Id);
        }
        public void Delete(User user)
        {
            context.Remove(user);
            context.SaveChanges();
        }
        public void SaveChanges(User customer)
        {
            context.Attach(customer).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Save(User customer)
        {
            context.Add(customer);
            context.SaveChanges();
        }

    }
}