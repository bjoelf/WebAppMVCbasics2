using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebAppMVCbasics2app.Models.ViewModel
{
    public class RolesManagementViewModel
    {
        public string UserId { get; set; }
        public IList<string> UserRoles { get; set; }
        public List<IdentityRole> IdentityRoles { get; set; }
        public RolesManagementViewModel(string userId, IList<string> userRoles, List<IdentityRole> identityRoles)
        {
            UserId = userId;
            UserRoles = UserRoles;
            IdentityRoles = identityRoles;
            FilterRoles();
        }

        void FilterRoles()
        {
            foreach (string item in UserRoles)
            {
                IdentityRoles.Remove(IdentityRoles.Single(r => r.Name.Equals(item)));
            }
        }
    }
}
