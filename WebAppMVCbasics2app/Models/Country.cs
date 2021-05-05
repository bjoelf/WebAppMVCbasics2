using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVCbasics2app.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string CountryName { get; set; }

        [Required]
        public City CityInCountry { get; set; }

        [ForeignKey("CityInCountry")]
        public int CityInCountryId { get; set; }

    }
}
