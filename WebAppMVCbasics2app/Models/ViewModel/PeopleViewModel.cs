using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class PeopleViewModel
    {
        //CreatePersonViewModel – Use to prevent overposting and to use data

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }

        public List<PeopleViewModel> PeopleList { get; set; }
    }
}
