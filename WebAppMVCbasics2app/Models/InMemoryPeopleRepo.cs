using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVCbasics2app.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        static List<Person> PersonList = new List<Person>();
        static int idCounter = 0;

        public InMemoryPeopleRepo()
        {
            if (PersonList.Count == 0)
            {
                Create(new Person() { Name = "Björn Elfvin", Phone = "+46706952593", City = "Hovmantorp" });
                Create(new Person() { Name = "Lilleman", Phone = "+4670123456", City = "Hovmantorp" });
                Create(new Person() { Name = "Anders Andersson", Phone = "+4670654321", City = "Tingsryd" });
                Create(new Person() { Name = "Johan Johansson", Phone = "+4670987654", City = "Växjö" });
            }
        }
        public Person Create(Person person)
        {
            person.Id = ++idCounter;
            PersonList.Add(person);
            return person;
        }

        public List<Person> Read()
        {
            return PersonList;
        }

        public Person Read(int id)
        {
            Person p = PersonList.Find(x => x.Id == id);
            return p;
        }

        public Person Update(Person person)
        {
            PersonList[person.Id] = person;
            return PersonList[person.Id];
        }
        public bool Delete(Person person)
        {
            PersonList.Remove(person);
            Person person1 = Read(person.Id);
            if (person1 == null)
                return true;
            return false;
        }
    }
}
