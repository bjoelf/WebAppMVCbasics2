using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Interfaces;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Database
{
    public class DbLanguageRepo : ILanguageRepo
    {
        private readonly PeopleDbContext _peopleDbContext;
        public DbLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Language Create(Language language)
        {
            _peopleDbContext.Add(language);

            if (_peopleDbContext.SaveChanges() > 0)
                return language;

            return null;
        }
        public List<Language> Read()
        {
            return _peopleDbContext.Languages.ToList();
        }
        public Language Read(int id)
        {
            return _peopleDbContext.Languages.SingleOrDefault(x => x.Id == id);
        }
        public Language Update(Language language)
        {
            Language l = Read(language.Id);
            if (l == null)
                return null;

            _peopleDbContext.Update(language);
            int res = _peopleDbContext.SaveChanges();

            if (res == 0)
                return null;

            return l;
        }
        public bool Delete(int id)
        {
            Language l = Read(id);
            if (l == null)
                return false;

            _peopleDbContext.Languages.Remove(l);
            int res = _peopleDbContext.SaveChanges();

            if (res == 0)
                return false;

            return true;
        }
    }
}
