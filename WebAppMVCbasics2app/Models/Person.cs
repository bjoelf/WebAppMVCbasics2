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
        public string Name { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public City LiveInCity { get; set; }

        [ForeignKey("LiveInCity")]
        public int? CityId { get; set; }
        public List<PersonLanguage> PersonLanguage { get; set; }
    }
}
