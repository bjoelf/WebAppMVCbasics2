using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Interfaces;
using WebAppMVCbasics2app.Models.ViewModel;

namespace WebAppMVCbasics2app.Models
{
    public class CityService : ICityService
    {
        private readonly IPeopleRepo _peopleRepo;
        private readonly ICityRepo _cityRepo;
        private readonly ICountryRepo _countryRepo;

        public CityService(IPeopleRepo peopleRepo, ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            _cityRepo = cityRepo;
            _peopleRepo = peopleRepo;
            _countryRepo = countryRepo;
        }
        public City Add(CreateCity createCity)
        {
            City city = new City();
            city.CityName = createCity.CityName;
            city.Country = _countryRepo.Read(createCity.CountryId);

            return _cityRepo.Create(city);
        }

        public CityViewModel All()
        {
            CityViewModel vm = new CityViewModel();
            vm.CityList = _cityRepo.Read();
            return vm;
        }

        public City FindById(int id)
        {
            return _cityRepo.Read(id);
        }

        public City Edit(int id, CreateCity city)
        {
            City c = FindById(id);
            if (c == null)
                return null;

            c.CityName = city.CityName;

            c = _cityRepo.Update(c);

            return c;
        }

        public bool Remove(int id)
        {
            return _cityRepo.Delete(id);
        }
    }
}
