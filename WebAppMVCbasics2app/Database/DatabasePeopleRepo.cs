using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Database
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext peopleDbContext;

        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            this.peopleDbContext = peopleDbContext;
        }

        public Person Create(Person person)
        {
            peopleDbContext.Add(person);
            int change = peopleDbContext.SaveChanges();

            if (change == 0) // no change in db.
            {
                throw new Exception("Unable to att car to database");
            }
            return person;
        }

        public bool Delete(Person person)
        {
            peopleDbContext.Remove(person);
            if (this.Read(person.Id) == null)
            {
                return true;
            }
            return false;
        }

        public List<Person> Read()
        {
            return peopleDbContext.People.ToList();
        }

        public Person Read(int id)
        {
            return peopleDbContext.People.SingleOrDefault(row => row.Id == id);
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
