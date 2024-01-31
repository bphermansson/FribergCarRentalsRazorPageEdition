using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FribergsCarRentals.DataAccess.Data
{
    public interface IUsersRepository
    {
        User Get(int Id);
        User GetByEmail(string Email);
        List<User> GetAll();
        public bool CustomerExists(int Id);
        void Delete(User Customer);
        public void SaveChanges(User Customer);
        public void Save(User Customer);

    }
}
