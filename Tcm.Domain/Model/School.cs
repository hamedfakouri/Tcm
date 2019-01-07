using System.Collections.Generic;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class School : EntityBase<int>
    {
        public string Name { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public string Region { get; set; }

//        Introducing FOREIGN KEY constraint 'FK_SchoolEducationSubCourses_Schools_SchoolId' on table 'SchoolEducationSubCourses' may cause cycles or multiple cascade paths.Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
//Could not create constraint or index.See previous errors.
        //public short EducationCourseId { get; set; }
        //public EducationCourse EducationCourse  { get; set; }

        public short SchoolTypeId { get; set; }
        public SchoolType SchoolType { get; set; }

        public short SchoolSubTypeId { get; set; }
        public SchoolSubType SchoolSubType { get; set; }

        public List<SchoolEducationSubCourse> SchoolEducationSubCourses { get; set; }

        /// <summary>
        /// 0:Men , 1:Women
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 0:Sobhi , 1:Asri
        /// </summary>
        public bool ShiftType { get; set; }

        public int TotalStudentCount { get; set; }
        public int RegisterStudentCount { get; set; }
        public string CreationDate { get; set; }
        public string SchoolNumber { get; set; }
        public string FounderName { get; set; }
        public string ManagerName { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public string WebUrl { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }

    }
    
}
