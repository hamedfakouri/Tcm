﻿using System.Collections.Generic;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class ClassRoom : EntityBase<long>
    {
        public string Name { get; set; }
        public long SchoolEducationSubCourseId { get; set; }
        public short Year { get; set; }
        public SchoolEducationSubCourse SchoolEducationSubCourse { get; set; }
        public List<ClassStudent> ClassStudents { get; set; }
    }
}
