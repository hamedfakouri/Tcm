using System;
using System.Collections.Generic;
using System.Text;

namespace Tcm.Application.Contract.Students
{
   public class StudentDto
    {
        public string StudentNumber { get; set; }
        public string Phone { get; set; }
        public string TrackerPhone { get; set; }
        public string FatherName { get; set; }
        public string FatherPhone { get; set; }
        public string HomeAddress { get; set; }
        public string HomePhone { get; set; }
     
        public int ApplicationUserId { get; set; }
      
    }

   
}
