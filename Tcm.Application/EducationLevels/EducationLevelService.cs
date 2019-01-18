using System;
using System.Collections.Generic;
using System.Text;
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
        public void Add(EducationLevelDto educationLevelDto)
        {
            var educationLevel = new EducationLevel() {
                Name = educationLevelDto.Name
            };

            _educationLevelRepository.Add(educationLevel);
           

        }

        public void Add(EducationLevelAddDto educationLevelDto)
        {
            throw new NotImplementedException();
        }

        public EducationLevelDto Get(short id)
        {
            var educationLevel = _educationLevelRepository.GetById(id);

            var dto = new EducationLevelDto()
            {
                Id = educationLevel.Id,
                Name = educationLevel.Name
            };

            return dto;

        }
    }
}
