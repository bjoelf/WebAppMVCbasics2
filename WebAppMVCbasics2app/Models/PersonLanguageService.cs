using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Interfaces;

namespace WebAppMVCbasics2app.Models
{
    public class PersonLanguageService : IPersonLanguageService
    {
        private readonly IPersonLanguageRepo _personLanguageRepo;
        public PersonLanguageService(IPersonLanguageRepo personLanguageRepo)
        {
            _personLanguageRepo = personLanguageRepo;
        }
        public PersonLanguage Add(PersonLanguage personLanguage)
        {
            return _personLanguageRepo.Create(personLanguage);
        }
        public PersonLanguage Add(int id, int languageId)
        {
            PersonLanguage pl = new PersonLanguage();
            pl.LanguageId = languageId;
            pl.PersonId = id;
            return Add(pl);
        }
        public List<PersonLanguage> All()
        {
            return _personLanguageRepo.Read();
        }
        public PersonLanguage FindbyId(int id, int personLanguageId)
        {
            return _personLanguageRepo.Read(id, personLanguageId);
        }
        public List<PersonLanguage> FindbyId(int id)
        {
            return _personLanguageRepo.Read(id);
        }
        public bool Remove(int id, int personLanguageId)
        {
            return _personLanguageRepo.Delete(id, personLanguageId);
        }
    }
}
