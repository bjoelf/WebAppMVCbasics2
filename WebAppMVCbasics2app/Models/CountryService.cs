using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Interfaces;
using WebAppMVCbasics2app.Models.ViewModel;

namespace WebAppMVCbasics2app.Models
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;
        private readonly ICityRepo _cityRepo;
        public CountryService(ICountryRepo countryRepo, ICityRepo cityRepo)
        {
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
            
        }
        public Country Add(CreateCountry createCountry)
        {
            throw new NotImplementedException();
        }

        public List<Country> All()
        {
            throw new NotImplementedException();
        }

        public Country Edit(int id, CreateCountry country)
        {
            throw new NotImplementedException();
        }

        public Country FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
