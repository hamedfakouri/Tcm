using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.EducationCourses
{

    public interface IEducationCourseService:IApplicationService
    {
        void Add(EducationCourse educationCourseDto);

        EducationCourse Get(short Id);
 

        List<EducationCourseListDto> GetAll(UserParams userParams);

        List<EducationCourse> GetAll(Expression<Func<EducationCourse, bool>> expression);

        void Delete(short Id);

        void Update(short Id, EducationCourse educationCourse);


    }
}
