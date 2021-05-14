using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Interfaces
{
    public interface ILanguageRepo
    {
        public Language Create(Language language);
        public List<Language> Read();
        public Language Read(int Id);
        public Language Update(Language language);
        public bool Delete(int personId);
    }
}
