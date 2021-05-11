using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class CreateLanguage
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
