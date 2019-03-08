using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.ClassRooms
{
    public class ClassRoomDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long SchoolEducationSubCourseId { get; set; }
        public string EducationSubCourseName { get; set; }
        public string EducationCourseName { get; set; }
        public int StudentCount { get; set; }
        public int EducationYearId { get; set; }
        public string EducationYear { get; set; }

    }

    public class ClassRoomAddDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long SchoolEducationSubCourseId { get; set; }
        public int EducationYearId{ get; set; }
    }
}
