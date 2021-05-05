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

        public CityService(IPeopleRepo peopleRepo, ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
            _peopleRepo = peopleRepo;
        }
        public City Add(CreateCity createCity)
        {
            throw new NotImplementedException();
        }

        public List<City> All()
        {
            throw new NotImplementedException();
        }

        public City Edit(int id, CreateCity city)
        {
            throw new NotImplementedException();
        }

        public City FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
