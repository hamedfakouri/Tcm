using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.EducationLevels
{

    public interface IEducationLevelService:IApplicationService
    {
        void Add(EducationLevelAddDto educationLevelDto);

        EducationLevelDto Get(short Id);
 

        List<EducationLevelDto> GetAll(UserParams userParams);

        List<EducationLevel> GetAll(Expression<Func<EducationLevel, bool>> expression);

        void Delete(short Id);

        void Update(short Id, EducationLevelDto educationLevel);


    }
}
