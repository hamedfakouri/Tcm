using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Core;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
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
        public void Add(SchoolSubType schoolSubType)
        {
            var item = new SchoolSubType()
            {
                Name = schoolSubType.Name,
                SchoolTypeId = schoolSubType.SchoolTypeId
            };

            _schoolSubTypeRepository.Add(item);

        }

        public void Delete(short Id)
        {
            var schoolSubType = Get(Id);
            if (schoolSubType != null)
                _schoolSubTypeRepository.Delete(schoolSubType);
        }

        public SchoolSubType Get(short id)
        {
            return _schoolSubTypeRepository.GetById(id);


        }

        public List<SchoolSubTypeDto> GetAll(UserParams userParams)
        {
            return _schoolSubTypeRepository.GetAll().Include(t => t.SchoolType).Pager(userParams).ToList().Mapper();

        }

        public List<SchoolSubType> GetAll(Expression<Func<SchoolSubType, bool>> expression)
        {
            return _schoolSubTypeRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, SchoolSubType model)
        {
            var schoolSubType = _schoolSubTypeRepository.GetById(Id);

            if (schoolSubType != null)
            {
                schoolSubType.Name = model.Name;
                schoolSubType.SchoolTypeId = model.SchoolTypeId;

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
                dto.SchoolTypeName = schoolSubType.SchoolType.Name;

            }

            return dto;
        }
       
    }

}
