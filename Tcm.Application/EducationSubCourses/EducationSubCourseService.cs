using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
using Microsoft.EntityFrameworkCore;
using Tcm.Application.Contract.EducationSubCourses;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.EducationSubCourses
{
    public class EducationSubCourseService : IEducationSubCourseService
    {

        private IEducationSubCourseRepository _EducationSubCourseRepository;
        public EducationSubCourseService(IEducationSubCourseRepository EducationSubCourseRepository)
        {
            _EducationSubCourseRepository = EducationSubCourseRepository;
        }
        public void Add(EducationSubCourse EducationSubCourseDto)
        {
            var EducationSubCourse = new EducationSubCourse()
            {
                Name = EducationSubCourseDto.Name,
                EducationCourseId = EducationSubCourseDto.EducationCourseId,
            };

            _EducationSubCourseRepository.Add(EducationSubCourse);

        }

        public void Delete(short Id)
        {
            var EducationSubCourse = Get(Id);
            if (EducationSubCourse != null)
                _EducationSubCourseRepository.Delete(EducationSubCourse);
        }

        public EducationSubCourse Get(short id)
        {
            return _EducationSubCourseRepository.GetById(id);


        }

        public List<EducationSubCourseListDto> GetAll(UserParams userParams)
        {
            return _EducationSubCourseRepository.GetAll().Include(t => t.EducationCourse)
                .Include(t => t.EducationCourse.EducationLevel)
                .Pager(userParams).ToList().Mapper();
        }

        public List<EducationSubCourse> GetAll(Expression<Func<EducationSubCourse, bool>> expression)
        {
            return _EducationSubCourseRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, EducationSubCourse model)
        {
            var EducationSubCourse = _EducationSubCourseRepository.GetById(Id);

            if (EducationSubCourse != null)
            {
                EducationSubCourse.Name = model.Name;

                _EducationSubCourseRepository.Update(EducationSubCourse);
            }
        }
    }

    public static class EducationSubCourseMapper
    {
        public static List<EducationSubCourseListDto> Mapper(this List<EducationSubCourse> EducationSubCourses)
        {
            var items = new List<EducationSubCourseListDto>();
            EducationSubCourses.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static EducationSubCourseListDto Mapper(this EducationSubCourse EducationSubCourse)
        {
            var dto = new EducationSubCourseListDto();

            if (EducationSubCourse == null)
                return dto;

            dto.Id = EducationSubCourse.Id;
            dto.Name = EducationSubCourse.Name;
            dto.EducationCourseId = EducationSubCourse.EducationCourseId;
            dto.EducationCourseName = EducationSubCourse.EducationCourse.Name;
            dto.EducationLevelName = EducationSubCourse.EducationCourse.EducationLevel.Name;
            return dto;
        }
    }

}
