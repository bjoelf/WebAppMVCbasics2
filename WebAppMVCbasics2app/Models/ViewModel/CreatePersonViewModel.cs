using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class CreatePersonViewModel
    {
        //CreatePersonViewModel – Use to prevent overposting and to use data
        //annotations to validate inputs when creating new person

        [Required]
        public string ForName { get; set; }
        //[Required]
        public string LastName { get; set; }
        //[Required]
        public string DayOfBirth { get; set; }

        [Required]
        public string Phone { get; set; }
        public List<City> LiveInCity { get; set; }
        //changed to [Required]
       // [Required]
        public int CityId { get; set; }
    }
}
