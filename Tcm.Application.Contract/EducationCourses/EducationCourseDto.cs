using System;
using System.Collections.Generic;
using System.Text;

namespace Tcm.Application.Contract.EducationCourses
{
    public class EducationCourseListDto
    {
        public short Id { get; set; }
        public short EducationLevelId { get; set; }
        public string Name { get; set; }
        public bool AllowAssignMajor { get; set; }
        public string EducationLevelTitle { get; set; }
    }

}
