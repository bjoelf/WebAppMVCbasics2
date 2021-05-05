using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;
using WebAppMVCbasics2app.Models.ViewModel;

namespace WebAppMVCbasics2app.Interfaces
{
    public interface ICountryService
    {
        Country Add(CreateCountry createCountry);
        List<Country> All();
        Country FindById(int id);
        Country Edit(int id, CreateCountry country);
        bool Remove(int id);
    }
}
