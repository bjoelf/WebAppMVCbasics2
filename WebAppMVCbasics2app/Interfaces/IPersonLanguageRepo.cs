using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Interfaces
{
    public interface IPersonLanguageRepo
    {
        public PersonLanguage Create(PersonLanguage personLanguage);
        public List<PersonLanguage> Read();
        public PersonLanguage Read(int Id);
        public bool Delete(int personLanguageId);
    }
}
