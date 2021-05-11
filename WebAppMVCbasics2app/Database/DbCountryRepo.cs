using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Interfaces;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Database
{
    public class DbCountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DbCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Country Create(Country country)
        {
            _peopleDbContext.Add(country);

            int ret = _peopleDbContext.SaveChanges();

            if (ret == 0)
                return null;

            return country;
        }
        public Country Read(int id)
        {
            return _peopleDbContext.Countries.Find(id);
        }
        public List<Country> Read()
        {
            return _peopleDbContext.Countries.ToList();
        }

        public Country Update(Country country)
        {
            Country c = Read(country.Id);
            if (c == null)
                return null;

            _peopleDbContext.Update(country);
            int res = _peopleDbContext.SaveChanges();

            if (res == 0)
                return null;

            return c;
        }
        public bool Delete(int id)
        {
            Country c = Read(id);

            if (c == null)
                return false;

            _peopleDbContext.Countries.Remove(c);
            int res = _peopleDbContext.SaveChanges();

            if (res == 0)
                return false;

            return true;
        }
    }
}
