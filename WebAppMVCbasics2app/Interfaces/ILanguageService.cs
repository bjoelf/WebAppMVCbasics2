using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;
using WebAppMVCbasics2app.Models.ViewModel;

namespace WebAppMVCbasics2app.Interfaces
{
    public interface ILanguageService
    {
        Language Add(CreateLanguage CreateLanguage);
        List<Language> All();
        Language FindbyId(int id);
        Language Edit(int id, CreateLanguage language);
        bool Remove(int id);
    }
}
