using System.ComponentModel.DataAnnotations;

namespace FribergsCarRentals.DataAccess.Data
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        //public int BookingId { get; set; }
        public int CarId { get; set; }
        public string Customer { get; set; }
        public DateOnly BookingDate { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly StopDate { get; set; }
    }
}
