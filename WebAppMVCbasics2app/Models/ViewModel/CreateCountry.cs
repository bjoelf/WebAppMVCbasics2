using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class CreateCountry
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string CountryName { get; set; }

        public List<Country> CountryList { get; set; }
    }
}
