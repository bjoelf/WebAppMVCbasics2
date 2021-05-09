using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;
using WebAppMVCbasics2app.Models.ViewModel;

namespace WebAppMVCbasics2app.Interfaces
{
    public interface ICityService
    {
        City Add(CreateCity createCity);
        CityViewModel All();
        City FindById(int id);
        City Edit(int id, CreateCity city);
        bool Remove(int id);
    }
}
