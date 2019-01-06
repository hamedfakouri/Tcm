using Framework.Persistence.Ef;
using System.Collections.Generic;

namespace Tcm.Domain.Model
{
    public class Major : EntityBase<short>
    {
        public string Name { get; set; }

        public List<SchoolEducationSubCourse> SchoolEducationSubCourses { get; set; }

    }
    
}
