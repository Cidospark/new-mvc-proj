using System.ComponentModel.DataAnnotations;

namespace DecaLib.Models
{
    public class Address
    {
        public string AddressId { get; set; }
        public string UserId { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


        //Navigation property
        public User User { get; set; }
    }
}