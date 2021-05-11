using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCbasics2app.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public List<PersonLanguage> PersonLanguage { get; set; }
    }
}
