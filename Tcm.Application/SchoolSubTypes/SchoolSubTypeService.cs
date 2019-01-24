using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Core;
using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using Tcm.Application.Contract.SchoolTypes;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.SchoolSubTypes
{
    public class SchoolSubTypeService : ISchoolSubTypeService
    {

        private ISchoolSubTypeRepository _schoolSubTypeRepository;
        public SchoolSubTypeService(ISchoolSubTypeRepository schoolSubTypeRepository)
        {
            _schoolSubTypeRepository = schoolSubTypeRepository;
        }
        public void Add(SchoolSubTypeDto schoolSubTypeDto)
        {
            var schoolSubType = new SchoolSubType() {
                Name = schoolSubTypeDto.Name,
                SchoolTypeId = schoolSubTypeDto.SchoolTypeId
            };

            _schoolSubTypeRepository.Add(schoolSubType);
           
        }

        public void Delete(short Id)
        {
            var schoolSubType = Get(Id);
            if(schoolSubType!=null)
            _schoolSubTypeRepository.Delete(schoolSubType.Mapper());
        }

        public SchoolSubTypeDto Get(short id)
        {
            return _schoolSubTypeRepository.GetById(id).Mapper();


        }

        public List<SchoolSubTypeDto> GetAll(UserParams userParams)
        {
            var items = _schoolSubTypeRepository.GetAll().Skip((userParams.PageNumber - 1) * userParams.PageSize).Take(userParams.PageSize).ToList().Mapper();

            return null;

        }

        public List<SchoolSubType> GetAll(Expression<Func<SchoolSubType, bool>> expression)
        {
            return _schoolSubTypeRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, SchoolSubTypeDto model)
        {
            var schoolSubType = _schoolSubTypeRepository.GetById(Id);
           
            if (schoolSubType != null)
            {
                schoolSubType.Name = model.Name;

                _schoolSubTypeRepository.Update(schoolSubType);
            }
        }
    }

    public static class SchoolSubTypeMapper
    {
        public static List<SchoolSubTypeDto> Mapper(this List<SchoolSubType> schoolSubTypes)
        {
            var items = new List<SchoolSubTypeDto>();
            schoolSubTypes.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static SchoolSubTypeDto Mapper(this SchoolSubType schoolSubType)
        {


            var dto = new SchoolSubTypeDto();

            if (schoolSubType != null)
            {
                dto.Id = schoolSubType.Id;
                dto.Name = schoolSubType.Name;
                dto.SchoolTypeId = schoolSubType.SchoolType.Id;
                dto.SchoolTypeName = schoolSubType.Name;

            }          

            return dto;
        }
        public static List<SchoolSubType> Mapper(this List<SchoolSubTypeDto> dtos)
        {
            var items = new List<SchoolSubType>();
            dtos.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static SchoolSubType Mapper(this SchoolSubTypeDto dto)
        {


            var model = new SchoolSubType();

            if (dto != null)
            {
                model.Id = dto.Id;
                model.Name = dto.Name;
                model.SchoolTypeId = dto.SchoolTypeId;
            }

            return model;
        }
    }
    
}
