using System.ComponentModel.DataAnnotations;

namespace FribergsCarRentals.DataAccess.Data
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        public int CarId { get; set; }
        public int Customer { get; set; }
        public string CustomerEmail { get; set; }
        public DateOnly BookingDate { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly StopDate { get; set; }
    }
}
