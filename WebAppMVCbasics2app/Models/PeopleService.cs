using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;


namespace WebAppMVCbasics2app.Models
{
    public class PeopleService :  IPeopleService 
    {
        IPeopleRepo _peopleRepo;

        public PeopleService()
        {
            //Only need to alter this line of code in changeing data source 
            _peopleRepo = new InMemoryPeopleRepo();
        }

        public Person Add(CreatePersonViewModel person)
        {
            Person p = new Person();

            p.Name = person.Name;
            p.Phone = person.Phone;
            p.City = person.City;

            p = _peopleRepo.Create(p);
            return p;
        }

        public PeopleViewModel All()
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm.PeopleList = _peopleRepo.Read();
            return vm;
        }

        public PeopleViewModel FindBy(PeopleViewModel find)
        {
            PeopleViewModel pvm = new PeopleViewModel();
            pvm.PeopleList = new List<Person>();

            foreach (Person item in _peopleRepo.Read())
            {
                //Måste göra om 
                if (!String.IsNullOrEmpty(find.Search) && item.Name.Contains(find.Search)) {
                    pvm.PeopleList.Add(item);
                }
                if (!String.IsNullOrEmpty(find.Search) && item.City.Contains(find.Search)) {
                    pvm.PeopleList.Add(item);
                }
            }
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
            {
                return null;
            }

            _person.Name = person.Name;
            _person.Phone = person.Phone;
            _person.City = person.City;

            _person = _peopleRepo.Update(_person);
            return _person;
        }
        public bool Remove(int id)
        {
            return _peopleRepo.Delete(_peopleRepo.Read(id));
        }

    }
}
