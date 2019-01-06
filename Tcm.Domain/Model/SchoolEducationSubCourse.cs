using Framework.Persistence.Ef;
using System.Collections.Generic;

namespace Tcm.Domain.Model
{
    public class SchoolEducationSubCourse  : EntityBase<long>
    {
        public long SchoolId { get; set; }
        public School School { get; set; }

        public short EducationSubCourseId { get; set; }
        public EducationSubCourse EducationSubCourse { get; set; }

        public short MajorId { get; set; }
        public Major Major { get; set; }

        public int ClassCount { get; set; }

        //public Student Student { get; set; }

        public List<ClassRoom> ClassRooms { get; set; }
    }
    
}
