using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DecaLib.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        //Navigation property
        public Address Address { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public User()
        {
            Photos = new HashSet<Photo>();
        }
    }
}
