using System;
using System.Collections.Generic;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class EducationCourse : EntityBase<short>
    {
        public string Name { get; set; }


        public short EducationLevelId { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public List<EducationSubCourse> EducationSubCourses { get; set; }

        public List<School> Schools { get; set; }

        public bool AllowAssignMajor { get; set; }
    }
    
}
