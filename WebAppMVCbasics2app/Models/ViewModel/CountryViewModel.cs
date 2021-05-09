using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class CountryViewModel
    {
        [Required]
        public string CountryName { get; set; }
        public List<City> CountryList { get; set; }
    }
}
