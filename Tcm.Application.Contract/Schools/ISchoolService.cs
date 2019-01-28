using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Application.Contract.SchoolTypes;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.Schools
{

    public interface ISchoolService:IApplicationService
    {
        void Add(SchoolDto School);

        SchoolDto Get(int Id);
 
        List<SchoolDto> GetAll(UserParams userParams);

        List<SchoolDto> GetAll(Expression<Func<School, bool>> expression);

        void Delete(int Id);

        void Update(int Id, SchoolDto School);


    }
}
