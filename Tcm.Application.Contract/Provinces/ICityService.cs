using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.Provinces
{

    public interface ICityService:IApplicationService
    {
        void Add(CityDto City);

        CityDto Get(int Id);
 

        List<CityDto> GetAll(UserParams userParams);

        List<CityDto> GetAll(Expression<Func<CityDto, bool>> expression);

        void Delete(int Id);

        void Update(int Id, CityDto City);


    }
}
