using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Domain.IdentityModel
{
   

        public class Role : IdentityRole<int> { }

        public class UserRole : IdentityUserRole<int> { }

        public class RoleClaim : IdentityRoleClaim<int> { }

        public class UserClaim : IdentityUserClaim<int> { }

        public class UserLogin : IdentityUserLogin<int> { }

        public class UserToken : IdentityUserToken<int> { }

        public class ApplicationUser : IdentityUser<int>
        {
        public bool IsAdmin { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public long NationalCode { get; set; }

        public Student Student { get; set; }
    }
    
}
