using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVCbasics2app.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(59)]
        public string ForName { get; set; }

        public string LastName { get; set; }

        public string DayOfBirth { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

       // [Required]
        public City LiveInCity { get; set; }

        [ForeignKey("LiveInCity")]
        public int? CityId { get; set; }
        public List<PersonLanguage> PersonLanguage { get; set; }
    }
}
