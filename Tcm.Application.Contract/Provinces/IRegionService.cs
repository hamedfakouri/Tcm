using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Tcm.Application.Contract.Provinces
{
    public interface IRegionService
    {
        void Add(RegionDto Region);

        RegionDto Get(int Id);

        List<RegionDto> GetAll(UserParams userParams);

        List<RegionDto> GetAll(Expression<Func<RegionDto, bool>> expression);

        void Delete(int Id);

        void Update(int Id, RegionDto Region);
    }
}
