using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.Students
{

    public interface IStudentService:IApplicationService
    {
        void Add(StudentDto educationLevelDto);

        StudentDto Get(long Id);
 

        List<StudentDto> GetAll(UserParams userParams);

        List<Student> GetAll(Expression<Func<Student, bool>> expression);

        void Delete(long Id);

        void Update(long Id, StudentDto educationLevel);


    }
}
