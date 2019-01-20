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

        public void Delete(short Id)
        {
            var educationLevel = Get(Id);
            if(educationLevel!=null)
            _educationLevelRepository.Delete(educationLevel.Mapper());
        }

        public EducationLevelDto Get(short id)
        {
           return  _educationLevelRepository.GetById(id).Mapper();

           
        }

        public List<EducationLevelDto> GetAll(UserParams userParams)
        {
            var items = _educationLevelRepository.GetAll().Skip((userParams.PageNumber - 1) * userParams.PageSize).Take(userParams.PageSize).ToList().Mapper();

            return null;

        }

        public List<EducationLevel> GetAll(Expression<Func<EducationLevel, bool>> expression)
        {
            return _educationLevelRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, EducationLevelDto model)
        {
            var educationLevel = _educationLevelRepository.GetById(Id);
           
            if (educationLevel != null)
            {
                educationLevel.Name = model.Name;

                _educationLevelRepository.Update(educationLevel);
            }
        }
    }

    public static class EducationLevelMapper
    {
        public static List<EducationLevelDto> Mapper(this List<EducationLevel> educationLevels)
        {
            var items = new List<EducationLevelDto>();
            educationLevels.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static EducationLevelDto Mapper(this EducationLevel educationLevel)
        {


            var dto = new EducationLevelDto();

            if (educationLevel != null)
            {
                dto.Id = educationLevel.Id;
                dto.Name = educationLevel.Name;
            }          

            return dto;
        }
        public static List<EducationLevel> Mapper(this List<EducationLevelDto> educationLevels)
        {
            var items = new List<EducationLevel>();
            educationLevels.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static EducationLevel Mapper(this EducationLevelDto educationLevel)
        {


            var dto = new EducationLevel();

            if (educationLevel != null)
            {
                dto.Id = educationLevel.Id;
                dto.Name = educationLevel.Name;
            }

            return dto;
        }
    }
    
}
