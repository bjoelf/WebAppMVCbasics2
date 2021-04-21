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
            //Only need to alter this line of code in change data source 
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

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            PeopleViewModel pvm = new PeopleViewModel();
            foreach (Person item in _peopleRepo.Read())
            {
                if (item.Name == search.Name || item.City == search.City)
                {
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
            Person p = FindBy(id);

            if (p == null)
            {
                return null;
            }

            p.Name = person.Name;
            p.Phone = person.Phone;
            p.City = person.City;

            p = _peopleRepo.Update(p);

            return p;
        }

        public bool Remove(int id)
        {
            return _peopleRepo.Delete(_peopleRepo.Read(id));
        }

    }
}
