using System.Collections.Generic;
using Framework.Persistence.Ef;
using Tcm.Domain.IdentityModel;

namespace Tcm.Domain.Model
{
    public class Student : EntityBase<long>
    {
       
        public string StudentNumber { get; set; }
        public string Phone { get; set; }
        public string TrackerPhone { get; set; }
        public string FatherName { get; set; }
        public string FatherPhone { get; set; }
        public string HomeAddress { get; set; }
        public string HomePhone { get; set; }
        public List<ClassStudent> ClassStudents { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
    
}
