using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.Administrator
{
    public class ClaimStore
    {
        public ClaimStore()
        {

        }
        public ClaimStore(string ClaimType, string ClaimValue)
        {
            claimstore.Add(new Claim(ClaimType, ClaimValue));
        }
        public static List<Claim> claimstore = new List<Claim>()
        {
            new Claim("Create User", "Create User"),
            new Claim("Edit User","Edit User"),
            new Claim("Delete User","Delete User"),
            new Claim("Update Status","Update Status"),
            new Claim("Allow Purchasing","Allow Purchasing")   
        };
    }
}
