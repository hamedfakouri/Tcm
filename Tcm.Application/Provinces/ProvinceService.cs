using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Core;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
using Tcm.Application.Contract.Provinces;
using Tcm.Application.Contract.SchoolTypes;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.SchoolTypes
{
    public class ProvinceService : IProvinceService
    {

        private IProvinceRepository _provinceRepository;

        private ICityRepository _cityRepository;

        private IRegionRepository _regionRepository;
        public ProvinceService(IProvinceRepository provinceRepository, ICityRepository cityRepository, IRegionRepository regionRepository)
        {
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _regionRepository = regionRepository;
        }
       

        
       
     

        public List<ProvinceDto> GetAll(Expression<Func<Province, bool>> expression)
        {
            return _provinceRepository.GetAll().Select(x => new ProvinceDto()
            {
                Id = x.Id,
                Name = x.Name
            }).OrderBy(x => x.Name).ToList();
        }

        

        public List<CityDto> GetAllCities(short id)
        {
            var items = _cityRepository.GetAll(x => x.ProvinceId == id).Select(x=> new CityDto() {
                Id = x.Id,
                Name =x.Name
            }).OrderBy(x => x.Name).ToList();
            return items;
        }

        public List<RegionDto> GetAllRegions(int cityId)
        {
            var items = _regionRepository.GetAll(c => c.CityId == cityId).Select(x => new RegionDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return items;
        }

     
       
    }

    
}
