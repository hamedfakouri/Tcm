using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.EducationYears
{

    public interface IEducationYearService:IApplicationService
    {
        void Add(EducationYearDto EducationYearDto);

        EducationYearDto Get(short Id);
 

        List<EducationYearDto> GetAll(UserParams userParams);

        List<EducationYear> GetAll(Expression<Func<EducationYear, bool>> expression);

        void Delete(short Id);

        void Update(short Id, EducationYearDto EducationYear);


    }
}
