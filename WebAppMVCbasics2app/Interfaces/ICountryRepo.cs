using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Interfaces
{
    public interface ICountryRepo
    {
        Country Create(Country country);
        Country Read(int id);
        List<Country> Read();
        Country Update(Country country);
        bool Delete(int id);
    }
}
