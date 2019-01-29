using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Application.Contract.Provinces
{

    public interface IProvinceService:IApplicationService
    {
       

      

        List<ProvinceDto> GetAll(Expression<Func<Province, bool>> expression);

        List<CityDto> GetAllCities(short id);

        List<RegionDto> GetAllRegions(int cityId);



      


    }
}
