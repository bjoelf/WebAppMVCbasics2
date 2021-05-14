using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Interfaces;
using WebAppMVCbasics2app.Models;


namespace WebAppMVCbasics2app.Database
{
    public class DbPersonLanguageRepo : IPersonLanguageRepo
    {
        private readonly PeopleDbContext _peopleDbContext;
        public DbPersonLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public PersonLanguage Create(PersonLanguage personLanguage)
        {
            _peopleDbContext.Add(personLanguage);

            if (_peopleDbContext.SaveChanges() > 0)
                return personLanguage;

            return null;
        }
        public List<PersonLanguage> Read()
        {
            return _peopleDbContext.PersonLanguages.ToList();
        }
        public PersonLanguage Read(int id)
        {
            return _peopleDbContext.PersonLanguages.SingleOrDefault(x => x.LanguageId == id);
        }
        public bool Delete(int id)
        {
            PersonLanguage pl = Read(id);
            if (pl == null)
                return false;

            _peopleDbContext.Remove(id);
            int res = _peopleDbContext.SaveChanges();

            if (res == 0)
                return false;

            return true;
        }
    }
}
