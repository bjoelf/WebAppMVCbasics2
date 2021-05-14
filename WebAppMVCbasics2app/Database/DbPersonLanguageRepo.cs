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
        public PersonLanguage Read(int id, int languageId)
        {
            return _peopleDbContext.PersonLanguages.SingleOrDefault(pl => pl.PersonId == id  && pl.LanguageId == languageId);
        }
        public List<PersonLanguage> Read(int id)
        {
            return _peopleDbContext.PersonLanguages.Where(pl => pl.PersonId == id).ToList();
        }
        public bool Delete(int id, int languageId)
        {
            PersonLanguage pl = Read(id, languageId);
            if (pl == null)
                return false;

            _peopleDbContext.Remove(pl);
            int res = _peopleDbContext.SaveChanges();

            if (res == 0)
                return false;

            return true;
        }
    }
}
