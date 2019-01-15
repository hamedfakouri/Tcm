using Framework.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.EducationLevels
{

    public interface IEducationLevelService:IApplicationService
    {
        void Add(EducationLevelAddDto educationLevelDto);

        EducationLevelDto Get(short Id);


    }
}
