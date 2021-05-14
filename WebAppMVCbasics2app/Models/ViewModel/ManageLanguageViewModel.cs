using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class ManageLanguageViewModel
    {
        public Person Person { get; set; }
        public List<Language> Languages { get; set; }
    }
}
