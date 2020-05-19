using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.Administrator
{
    public class UserCliamsViewModel
    {
        public UserCliamsViewModel()
        {
            Claims = new List<UserClaims>();
        }
        public string userId { get; set; }
        public List<UserClaims> Claims { get; set; }
    }
    public class UserClaims
    {
        public string ClaimType { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
    }
}
