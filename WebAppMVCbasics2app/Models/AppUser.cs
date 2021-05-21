using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebAppMVCbasics2app.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public string BirthDate { get; set; }
    }
}
