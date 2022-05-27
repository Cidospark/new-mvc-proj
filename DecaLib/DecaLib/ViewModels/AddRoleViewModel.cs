using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DecaLib.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public ICollection<string> Roles { get; set; }

        public AddRoleViewModel()
        {
            Roles = new HashSet<string>();
        }
    }
}
