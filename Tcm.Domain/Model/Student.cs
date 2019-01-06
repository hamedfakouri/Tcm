using System.Collections.Generic;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class Student : EntityBase<long>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public long NationalCode { get; set; }
        public string StudentNumber { get; set; }
        public string StudentPhone { get; set; }
        public string TrackerPhone { get; set; }
        public string FatherName { get; set; }
        public string FatherPhone { get; set; }
        public string HomeAddress { get; set; }
        public string HomePhone { get; set; }
        public List<ClassStudent> ClassStudents { get; set; }
    }
    
}
