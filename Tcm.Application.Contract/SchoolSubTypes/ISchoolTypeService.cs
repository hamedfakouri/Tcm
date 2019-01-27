using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Tcm.Domain.Model;

namespace Tcm.Application.Contract.SchoolTypes
{

    public interface ISchoolSubTypeService:IApplicationService
    {
        void Add(SchoolSubType schoolSubType);

        SchoolSubType Get(short Id); 

        List<SchoolSubTypeDto> GetAll(UserParams userParams);

        List<SchoolSubType> GetAll(Expression<Func<SchoolSubType, bool>> expression);

        void Delete(short Id);

        void Update(short Id, SchoolSubType schoolSubType);




    }
}
