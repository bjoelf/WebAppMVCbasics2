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
        [StringLength(60, MinimumLength = 5)]

        public string CityName { get; set; }

        //TODO: Lägg till foreign key i CreateCity
        [Required]
        public int CountryId { get; set; }
    }
}
