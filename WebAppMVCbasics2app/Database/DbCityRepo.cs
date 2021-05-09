using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Interfaces;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Database
{
    public class DbCityRepo : ICityRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DbCityRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public City Create(City city)
        {
            _peopleDbContext.Add(city);

            int ret = _peopleDbContext.SaveChanges();

            if (ret == 0)
                return null;

            return city;
        }
        public City Read(int id)
        {
            return _peopleDbContext.Cities.Find(id);
        }
        public List<City> Read()
        {
            return _peopleDbContext.Cities.ToList();
        }
        public City Update(City city)
        {
            City c = Read(city.Id);

            if (c == null)
                return null;

            _peopleDbContext.Update(city);
            int res = _peopleDbContext.SaveChanges();

            if (res == 0)
                return null;

            return c;
        }
        public bool Delete(int id)
        {
            City c = Read(id);

            if (c == null)
                return false;

            _peopleDbContext.Cities.Remove(c);
            int res = _peopleDbContext.SaveChanges();

            if (res == 0)
                return false;
 
            return true;
        }
   }
}
