using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.SchoolEducationSubCourses
{

    public interface ISchoolEducationSubCourseService : IApplicationService
    {
        SchoolEducationSubCourseDto Get(short Id);
        List<SchoolEducationSubCourseDto> GetAll(Expression<Func<SchoolEducationSubCourse, bool>> expression);
    }
}
