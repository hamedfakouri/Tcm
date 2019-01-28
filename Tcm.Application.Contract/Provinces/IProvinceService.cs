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
        void Add(ProvinceDto Province);

        ProvinceDto Get(short Id);
 

        List<ProvinceDto> GetAll(UserParams userParams);

        List<ProvinceDto> GetAll(Expression<Func<ProvinceDto, bool>> expression);

        void Delete(short Id);

        void Update(short Id, ProvinceDto Province);


    }
}
