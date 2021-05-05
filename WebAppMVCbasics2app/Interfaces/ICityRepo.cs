using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Interfaces
{
    public interface ICityRepo
    {
        City Create(City city);

        City Read(int id);

        List<City> Read();

        bool Delete(int id);
    }
}
