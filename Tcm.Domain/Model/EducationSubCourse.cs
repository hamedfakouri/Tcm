using System.Collections.Generic;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class EducationSubCourse : EntityBase<short>
    {
        public string Name { get; set; }


        public short EducationCourseId { get; set; }

        public EducationCourse EducationCourse { get; set; }

        public List<SchoolEducationSubCourse> SchoolEducationSubCourses { get; set; }
    }
    
}
