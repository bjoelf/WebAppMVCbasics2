using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class PeopleViewModel 
    {
        //PeopleViewModel – container for the information you need in your people view.
        //[Required]
        //public string Name { get; set; }
        //[Required]
        //public string Phone { get; set; }
        ////[Required]
        //public string City { get; set; }

        public PeopleViewModel()
        {
            CreatePersonViewModel = new CreatePersonViewModel();
        }
        public List<Person> PeopleList { get; set; }
        public string Search { get; set; }
        public CreatePersonViewModel CreatePersonViewModel { get; set; }
    }
}
