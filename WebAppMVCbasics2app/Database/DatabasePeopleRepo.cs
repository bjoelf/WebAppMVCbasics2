﻿using System;
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
            return person;
        }

        public List<Person> Read()
        {
            return _peopleDbContext.People.Include("LiveInCity").ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.People.Include("LiveInCity").SingleOrDefault(row => row.Id == id);
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
