using System.ComponentModel.DataAnnotations;

namespace DecaLib.Models
{
    public class Address
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }

        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}