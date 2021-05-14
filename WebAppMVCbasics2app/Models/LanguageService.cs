using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Interfaces;
using WebAppMVCbasics2app.Models.ViewModel;

namespace WebAppMVCbasics2app.Models
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;
        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }
        public Language Add(CreateLanguage CreateLanguage)
        {
            Language language = new Language();
            language.Name = CreateLanguage.Name;
            return _languageRepo.Create(language);
        }
        public List<Language> All()
        {
            return _languageRepo.Read();
        }
        public Language Edit(int id, CreateLanguage language)
        {
            Language l = FindbyId(id);
            if (l == null)
                return null;

            l.Name = language.Name;
            l = _languageRepo.Update(l);

            return l;
        }
        public Language FindbyId(int id)
        {
            return _languageRepo.Read(id);
        }
        public bool Remove(int id)
        {
            return _languageRepo.Delete(id);
        }
    }
}
