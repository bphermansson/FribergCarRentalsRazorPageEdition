using System.ComponentModel.DataAnnotations;

namespace FribergsCarRentals.DataAccess.Data
{
    public class Booking
    {
        [Key]
        public int? ID { get; set; }
        public int? CarId { get; set; }
        public string? UserEmail { get; set; }
        public DateOnly? BookingDate { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? StopDate { get; set; }
        public int? Customer { get; set; }
        public int? CustomerID { get; set; }
        public int? UsersID { get; set; }
        public int? UserID { get; set; }

    }
}
