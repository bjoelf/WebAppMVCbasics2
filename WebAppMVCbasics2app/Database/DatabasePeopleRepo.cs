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
                throw new Exception("Unable to add person to database");
            }
            return person;
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
            Person p = Read(person.Id);
            if (p == null) 
                return null;
            
            peopleDbContext.Update(person);
            int res = peopleDbContext.SaveChanges();
            
            if (res == 0) 
                return null;
            
            return person;
        }

        public bool Delete(Person person)
        {
            Person p = Read(person.Id);

            if (p == null)
                return false;

            peopleDbContext.Remove(person);
            int result = peopleDbContext.SaveChanges();

            if (result == 0) 
                return false;

            return true;
        }
    }
}
