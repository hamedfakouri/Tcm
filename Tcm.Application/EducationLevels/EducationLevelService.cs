using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Core;
using Tcm.Application.Contract.EducationLevels;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.EducationLevels
{
    public class EducationLevelService : IEducationLevelService
    {

        private IEducationLevelRepository _educationLevelRepository;
        public EducationLevelService(IEducationLevelRepository educationLevelRepository)
        {
            _educationLevelRepository = educationLevelRepository;
        }
        public void Add(EducationLevelAddDto educationLevelDto)
        {
            var educationLevel = new EducationLevel() {
                Name = educationLevelDto.Name
            };

            _educationLevelRepository.Add(educationLevel);
           
        }
        

        public EducationLevelDto Get(short id)
        {
            var educationLevel = _educationLevelRepository.GetById(id);

            var dto = new EducationLevelDto();

            if (educationLevel != null)
            {
                dto.Id = educationLevel.Id;
                dto.Name = educationLevel.Name;
            }

            return dto;

        }

        public List<EducationLevelDto> GetAll(UserParams userParams)
        {
            var items = _educationLevelRepository.GetAll().Skip((userParams.PageNumber - 1) * userParams.PageSize).Take(userParams.PageSize).ToList();

            return null;

        }

        public List<EducationLevel> GetAll(Expression<Func<EducationLevel, bool>> expression)
        {
            return _educationLevelRepository.GetAll(expression).ToString();
        }

        private List<EducationLevelDto> Mapper(List<EducationLevel> educationLevels)
        {
            var items = new List<EducationLevelDto>();
            educationLevels.ForEach(x=> items.Add(Mapper(x)));
            return items;
        }

        private EducationLevelDto Mapper(EducationLevel educationLevel)
        {
            var dto = new EducationLevelDto
            {
                Id = educationLevel.Id,
                Name = educationLevel.Name
            };

            return dto;
        }
    }

    
}
