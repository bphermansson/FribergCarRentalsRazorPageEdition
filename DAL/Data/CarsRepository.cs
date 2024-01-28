﻿using Microsoft.EntityFrameworkCore;

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
        public void Delete(Car Car)
        {
            context.Remove(Car);
            context.SaveChangesAsync();
        }
        public void SaveChanges(Car Car)
        {
            context.Attach(Car).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Save(Car Car) 
        {
            context.Add(Car);
            context.SaveChanges();
        }
    }
}