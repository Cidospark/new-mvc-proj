﻿using System;
using System.Collections.Generic;

namespace DecaLib.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
