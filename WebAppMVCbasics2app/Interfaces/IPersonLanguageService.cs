using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Interfaces
{
    public interface IPersonLanguageService
    {
        PersonLanguage Add(PersonLanguage personLanguage);
        PersonLanguage Add(int id, int personLanguageId);
        List<PersonLanguage> All();
        PersonLanguage FindbyId(int id, int personLanguageId);
        List<PersonLanguage> FindbyId(int id);
        bool Remove(int id, int personLanguageId);
    }
}
