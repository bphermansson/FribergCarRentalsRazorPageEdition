using Microsoft.EntityFrameworkCore;

namespace FribergsCarRentals.DataAccess.Data
{
    public class CarsRepository : ICarsRepository
    {
        private FribergCarRentalsDbContext context;
        public CarsRepository(FribergCarRentalsDbContext context)
        {
            this.context = context;
        }

        public Car Get(int Id)
        {
            return context.Cars.Find(Id);
        }

        public IEnumerable<Car> GetAll()
        {
            return context.Cars.ToList();
        }
        public bool CarExists(int Id)
        {
            return context.Cars.Any(e => e.ID == Id);
        }
        public void Delete(Car car)
        {
            context.Remove(car);
            context.SaveChanges();
        }
        public void SaveChanges(Car car)
        {
            context.Attach(car).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Save(Car car) 
        {
            context.Add(car);
            context.SaveChanges();
        }
    }
}