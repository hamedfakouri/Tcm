using System;
using System.Collections.Generic;
using System.Text;
using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;

namespace Tcm.Domain.Model
{
  
    public class Information
    {
        public string Code { get; set; }

        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }
        public string BirthDate { get; set; }

        public int ? CityId { get; set; }
        public City City { get; set; }

    

    }
}
