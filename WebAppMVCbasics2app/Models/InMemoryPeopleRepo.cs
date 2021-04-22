﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVCbasics2app.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        static List<Person> PersonList = new List<Person>();
        static int idCounter = 0;

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
            //TODO: testa om denna funkar!
            PersonList[person.Id] = person;
            return PersonList[person.Id];
        }
        public bool Delete(Person person)
        {
            //TODO: testa även denna!
            PersonList.Remove(person);
            Person person1 = Read(person.Id);
            if (person1 != null)
                return true;
            return false;
        }
    }
}