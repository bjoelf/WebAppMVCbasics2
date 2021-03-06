using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAppMVCbasics2app.Models
{
    public interface IPeopleRepo
    {
        public Person Create(Person person);
        public List<Person> Read();
        public List<Person> ReadPerson();
        public Person Read(int id);
        public Person Update(Person person);
        public bool Delete(Person person);
    }
}
