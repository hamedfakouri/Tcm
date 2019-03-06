using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.SchoolEducationSubCourses
{
    public class SchoolEducationSubCourseDto
    {
        public long Id { get; set; }
        public long EducationSubCourseId { get; set; }
        public string EducationSubCourseName { get; set; }
        public long SchoolId { get; set; }
    }

}
