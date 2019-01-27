using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
using Microsoft.EntityFrameworkCore;
using Tcm.Application.Contract.EducationCourses;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.EducationCourses
{
    public class EducationCourseService : IEducationCourseService
    {

        private IEducationCourseRepository _educationCourseRepository;
        public EducationCourseService(IEducationCourseRepository educationCourseRepository)
        {
            _educationCourseRepository = educationCourseRepository;
        }
        public void Add(EducationCourse educationCourseDto)
        {
            var educationCourse = new EducationCourse()
            {
                Name = educationCourseDto.Name,
                EducationLevelId = educationCourseDto.EducationLevelId,
                AllowAssignMajor = educationCourseDto.AllowAssignMajor
            };

            _educationCourseRepository.Add(educationCourse);

        }

        public void Delete(short Id)
        {
            var educationCourse = Get(Id);
            if (educationCourse != null)
                _educationCourseRepository.Delete(educationCourse);
        }

        public EducationCourse Get(short id)
        {
            return _educationCourseRepository.GetById(id);


        }

        public List<EducationCourseListDto> GetAll(UserParams userParams)
        {
            return _educationCourseRepository.GetAll().Include(t => t.EducationLevel).Pager(userParams).ToList().Mapper();
        }

        public List<EducationCourse> GetAll(Expression<Func<EducationCourse, bool>> expression)
        {
            return _educationCourseRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, EducationCourse model)
        {
            var educationCourse = _educationCourseRepository.GetById(Id);

            if (educationCourse != null)
            {
                educationCourse.Name = model.Name;
                educationCourse.EducationLevelId = model.EducationLevelId;

                _educationCourseRepository.Update(educationCourse);
            }
        }
    }

    public static class EducationCourseMapper
    {
        public static List<EducationCourseListDto> Mapper(this List<EducationCourse> educationCourses)
        {
            var items = new List<EducationCourseListDto>();
            educationCourses.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static EducationCourseListDto Mapper(this EducationCourse educationCourse)
        {
            var dto = new EducationCourseListDto();

            if (educationCourse == null)
                return dto;

            dto.Id = educationCourse.Id;
            dto.EducationLevelId = educationCourse.EducationLevelId;
            dto.Name = educationCourse.Name;
            dto.AllowAssignMajor = educationCourse.AllowAssignMajor;
            dto.EducationLevelName = educationCourse.EducationLevel.Name;
            return dto;
        }
    }

}
