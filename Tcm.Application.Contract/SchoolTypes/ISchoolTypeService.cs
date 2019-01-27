using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Tcm.Domain.Model;

namespace Tcm.Application.Contract.SchoolTypes
{

    public interface ISchoolTypeService:IApplicationService
    {
        void Add(SchoolType SchoolType);

        SchoolType Get(short Id);
 

        List<SchoolType> GetAll(UserParams userParams);

        List<SchoolType> GetAll(Expression<Func<SchoolType, bool>> expression);

        void Delete(short Id);

        void Update(short Id, SchoolType SchoolType);


    }
}
