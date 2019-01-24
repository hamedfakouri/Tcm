using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Enum;

namespace Tcm.Application.Contract.ApplicationUsers
{
   public class ApplicationUserDto
    {
        public string Email { get; set; }

        public string Password { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long NationalCode { get; set; }

        public string StudentNumber { get; set; }
        public string Phone { get; set; }
        public string TrackerPhone { get; set; }
        public string FatherName { get; set; }
        public string FatherPhone { get; set; }
        public string HomeAddress { get; set; }
        public string HomePhone { get; set; }

        public string RoleName { get; set; }

    }
}
