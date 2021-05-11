using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class CityViewModel
    {
        //[Required]
        //public string CityName { get; set; }
        public List<City> CityList { get; set; }
    }
}
