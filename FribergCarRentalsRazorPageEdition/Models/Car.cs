namespace FribergCarRentalsMVC.Models
{
    public class Car
    {
        public int ID { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public int EngineType { get; set; } // An enum with electric, diesel, petrol, ...
        public int NoOfSeats { get; set; }
        public string? Color { get; set; }
        public int Price_per_day { get; set; }
        public string ImageLink { get; set; }
    }
}
