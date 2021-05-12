using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class CreateCity
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string CityName { get; set; }

        public int CountryId { get; set; }

        public List<Country> Countries { get; set; }
    }
}
