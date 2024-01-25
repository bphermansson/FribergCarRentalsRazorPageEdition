using System.ComponentModel.DataAnnotations;

namespace FribergsCarRentals.DataAccess.Data
{
    public class Customer
    {
        [Key]
        //public int CustomerId { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public List<Booking>? CustomerBookings { get; set; }
    }
}
