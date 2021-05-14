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
            Country country = new Country();
            country.CountryName = createCountry.CountryName;

            return _countryRepo.Create(country);
        }

        public CountryViewModel All()
        {
            CountryViewModel cvm = new CountryViewModel();
            cvm.CountryList = _countryRepo.Read();
            return cvm;
        }

        public Country FindById(int id)
        {
            return _countryRepo.Read(id);
        }

        public Country Edit(int id, CreateCountry country)
        {
            Country c = FindById(id);
            if (c == null)
                return null;

            c.CountryName = country.CountryName;

            c = _countryRepo.Update(c);

            return c;
        }

        public bool Remove(int id)
        {
            return _countryRepo.Delete(id);
        }
    }
}
