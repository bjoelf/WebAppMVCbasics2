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
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public List<City> LiveInCity { get; set; }
        public int CityId { get; set; }
    }
}
