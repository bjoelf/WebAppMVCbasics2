using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;
using WebAppMVCbasics2app.Interfaces;


namespace WebAppMVCbasics2app.Models
{
    public class PeopleService :  IPeopleService 
    {
        private readonly IPeopleRepo _peopleRepo;
        private readonly ICityRepo _cityRepo;

        public PeopleService(IPeopleRepo peopleRepo, ICityRepo cityRepo)
        {
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;
        }

        public Person Add(CreatePersonViewModel person)
        {
            Person pNew = new Person();

            pNew.Name = person.Name;
            pNew.Phone = person.Phone;
            pNew.CityId = person.CityId;

            pNew = _peopleRepo.Create(pNew);
            return pNew;
        }

        public PeopleViewModel All()
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm.PeopleList = _peopleRepo.Read();
            vm.CreatePersonViewModel.LiveInCity = _cityRepo.Read();
            return vm;
        }

        public List<Person> AllPerson()
        {
            return _peopleRepo.ReadPerson();
        }

        public PeopleViewModel FindBy(PeopleViewModel find)
        {
            PeopleViewModel pvm = new PeopleViewModel();
            pvm.PeopleList = _peopleRepo.Read().Where(x => x.Name.Contains(find.Search) || x.LiveInCity.CityName.Contains(find.Search)).ToList();
            return pvm;
          }
  
        public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }
        public Person Edit(int id, Person person)
        {
            Person _person = FindBy(id);

            if (_person == null)
                return null;

            _person.Name = person.Name;
            _person.Phone = person.Phone;
            _person.LiveInCity.CityName = person.LiveInCity.CityName;

            _person = _peopleRepo.Update(_person);
            return _person;
        }
        public bool Remove(int id)
        {
            Person p = _peopleRepo.Read(id);
            if (p != null)
                return _peopleRepo.Delete(p);
            return false;
        }
    }
}
