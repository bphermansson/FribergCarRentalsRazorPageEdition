using System.ComponentModel.DataAnnotations;

namespace FribergsCarRentals.DataAccess.Data
{
    public class Car
    {
        [Key]
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int EngineType { get; set; } // An enum with electric, diesel, petrol, ...
        public int NoOfSeats { get; set; }
        public string? Color { get; set; }
        public int PricePerDay { get; set; }
        public int RepairCost { get; set; }
        public bool InUse { get; set; }
        public string ImageLink { get; set; }
    }
}
