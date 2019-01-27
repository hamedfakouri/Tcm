using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.EducationSubCourses
{

    public interface IEducationSubCourseService:IApplicationService
    {
        void Add(EducationSubCourse EducationSubCourseDto);

        EducationSubCourse Get(short Id);
 

        List<EducationSubCourseListDto> GetAll(UserParams userParams);

        List<EducationSubCourse> GetAll(Expression<Func<EducationSubCourse, bool>> expression);

        void Delete(short Id);

        void Update(short Id, EducationSubCourse EducationSubCourse);


    }
}
