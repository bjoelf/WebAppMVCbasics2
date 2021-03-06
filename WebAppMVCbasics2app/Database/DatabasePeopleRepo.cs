using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;
using Microsoft.EntityFrameworkCore;


namespace WebAppMVCbasics2app.Database
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            this._peopleDbContext = peopleDbContext;
        }

        public Person Create(Person person)
        {
            _peopleDbContext.Add(person);
            int change = _peopleDbContext.SaveChanges();

            if (change == 0) // no change in db.
            {
                throw new Exception("Unable to add person to database");
            }

            //ny för att få med city namn etc till personTable.
            person = Read(person.Id);

            return person;
        }

        public List<Person> Read()
        {
            return _peopleDbContext.People.Include("LiveInCity").ToList();
        }
        public List<Person> ReadPerson()
        {
            List<Person> people = _peopleDbContext.People.Include(p => p.LiveInCity).ToList();

            foreach (var p in people)
            {
                p.LiveInCity.PersonInCity = null;

                if (p.LiveInCity.Country != null)
                    p.LiveInCity.Country.CityInCountry = null;
            }
            return people;
        }
        public Person Read(int id)
        {

            //Hantera null
            Person p = _peopleDbContext.People.Find(id);

            if (p != null)
            {
                p = _peopleDbContext.People.Include(person => person.PersonLanguage).ThenInclude(perLan => perLan.Language)
                                        .Include(person => person.LiveInCity)
                                        .ThenInclude(incity => incity.Country)
                                        .SingleOrDefault(row => row.Id == id);

                if (p.PersonLanguage != null)
                    foreach (var item in p.PersonLanguage)
                    {
                        item.Person = null;
                        item.Language.PersonLanguage = null;
                    }

                if (p.LiveInCity.Country != null)
                    p.LiveInCity.Country.CityInCountry = null;

                p.LiveInCity.PersonInCity = null;
            }
            return p;
        }

        public Person Update(Person person)
        {
            Person p = Read(person.Id);
            if (p == null) 
                return null;
            
            _peopleDbContext.Update(person);
            int res = _peopleDbContext.SaveChanges();
            
            if (res == 0) 
                return null;
            
            return person;
        }

        public bool Delete(Person person)
        {
            Person p = Read(person.Id);

            if (p == null)
                return false;

            _peopleDbContext.Remove(person);
            int result = _peopleDbContext.SaveChanges();

            if (result == 0) 
                return false;

            return true;
        }
    }
}
