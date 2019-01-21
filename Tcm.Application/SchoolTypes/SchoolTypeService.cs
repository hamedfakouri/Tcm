using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Core;
using Tcm.Application.Contract.SchoolTypes;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.SchoolTypes
{
    public class SchoolTypeService : ISchoolTypeService
    {

        private ISchoolTypeRepository _schoolTypeRepository;
        public SchoolTypeService(ISchoolTypeRepository schoolTypeRepository)
        {
            _schoolTypeRepository = schoolTypeRepository;
        }
        public void Add(SchoolTypeDto schoolTypeDto)
        {
            var schoolType = new SchoolType() {
                Name = schoolTypeDto.Name
            };

            _schoolTypeRepository.Add(schoolType);
           
        }

        public void Delete(short Id)
        {
            var schoolType = Get(Id);
            if(schoolType!=null)
            _schoolTypeRepository.Delete(schoolType.Mapper());
        }

        public SchoolTypeDto Get(short id)
        {
           return  _schoolTypeRepository.GetById(id).Mapper();

           
        }

        public List<SchoolTypeDto> GetAll(UserParams userParams)
        {
            var items = _schoolTypeRepository.GetAll().Skip((userParams.PageNumber - 1) * userParams.PageSize).Take(userParams.PageSize).ToList().Mapper();

            return null;

        }

        public List<SchoolType> GetAll(Expression<Func<SchoolType, bool>> expression)
        {
            return _schoolTypeRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, SchoolTypeDto model)
        {
            var schoolType = _schoolTypeRepository.GetById(Id);
           
            if (schoolType != null)
            {
                schoolType.Name = model.Name;

                _schoolTypeRepository.Update(schoolType);
            }
        }
    }

    public static class SchoolTypeMapper
    {
        public static List<SchoolTypeDto> Mapper(this List<SchoolType> schoolTypes)
        {
            var items = new List<SchoolTypeDto>();
            schoolTypes.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static SchoolTypeDto Mapper(this SchoolType schoolType)
        {


            var dto = new SchoolTypeDto();

            if (schoolType != null)
            {
                dto.Id = schoolType.Id;
                dto.Name = schoolType.Name;
            }          

            return dto;
        }
        public static List<SchoolType> Mapper(this List<SchoolTypeDto> schoolTypes)
        {
            var items = new List<SchoolType>();
            schoolTypes.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static SchoolType Mapper(this SchoolTypeDto schoolType)
        {


            var dto = new SchoolType();

            if (schoolType != null)
            {
                dto.Id = schoolType.Id;
                dto.Name = schoolType.Name;
            }

            return dto;
        }
    }
    
}
