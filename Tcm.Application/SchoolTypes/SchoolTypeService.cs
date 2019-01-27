using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Core;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
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
        public void Add(SchoolType SchoolType)
        {
            var schoolType = new SchoolType()
            {
                Name = SchoolType.Name
            };

            _schoolTypeRepository.Add(schoolType);

        }

        public void Delete(short Id)
        {
            var schoolType = Get(Id);
            if (schoolType != null)
                _schoolTypeRepository.Delete(schoolType);
        }

        public SchoolType Get(short id)
        {
            return _schoolTypeRepository.GetById(id);
        }

        public List<SchoolType> GetAll(UserParams userParams)
        {
            var items = _schoolTypeRepository.GetAll().OrderBy(userParams.OrderBy, userParams.OrderByType).Skip((userParams.PageNumber - 1) * userParams.PageSize).Take(userParams.PageSize).ToList();

            return items;

        }

        public List<SchoolType> GetAll(Expression<Func<SchoolType, bool>> expression)
        {
            return _schoolTypeRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, SchoolType model)
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
      
    }

}
