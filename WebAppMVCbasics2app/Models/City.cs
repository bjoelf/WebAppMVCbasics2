using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVCbasics2app.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string CityName { get; set; }

        public List<Person> PersonInCity { get; set; }

        public Country Country { get; set; }
    }
}
