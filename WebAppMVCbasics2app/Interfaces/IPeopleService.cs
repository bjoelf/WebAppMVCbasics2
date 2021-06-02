using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;

namespace WebAppMVCbasics2app.Models
{
    public interface IPeopleService
    {
        public Person Add(CreatePersonViewModel person);
        public PeopleViewModel All();
        public List<Person> AllPerson();
        public PeopleViewModel FindBy(PeopleViewModel search);
        public Person FindBy(int id);
        Person Edit(int id, Person person);
        bool Remove(int id);
    }
}
