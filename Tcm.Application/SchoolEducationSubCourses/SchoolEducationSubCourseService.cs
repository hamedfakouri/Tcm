using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
using Microsoft.EntityFrameworkCore;
using Tcm.Application.Contract.SchoolEducationSubCourses;
using Tcm.Application.Contract.EducationLevels;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.SchoolEducationSubCourses
{
    public class SchoolEducationSubCourseService : ISchoolEducationSubCourseService
    {
        private readonly ISchoolEducationSubCourseRepository _SchoolEducationSubCourseRepository;
        public SchoolEducationSubCourseService(ISchoolEducationSubCourseRepository SchoolEducationSubCourseRepository)
        {
            _SchoolEducationSubCourseRepository = SchoolEducationSubCourseRepository;
        }

        public SchoolEducationSubCourseDto Get(short id)
        {
            return _SchoolEducationSubCourseRepository.GetAll().FirstOrDefault(x => x.Id == id).Mapper();

        }

        public List<SchoolEducationSubCourseDto> GetAll(Expression<Func<SchoolEducationSubCourse, bool>> expression)
        {
            var xxx = _SchoolEducationSubCourseRepository.GetAll(expression).Include(x => x.EducationSubCourse).ToList();
            return xxx.Mapper();
        }

    }

    public static class SchoolEducationSubCourseMapper
    {
        public static List<SchoolEducationSubCourseDto> Mapper(this List<SchoolEducationSubCourse> SchoolEducationSubCourses)
        {
            var items = new List<SchoolEducationSubCourseDto>();
            SchoolEducationSubCourses.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static SchoolEducationSubCourseDto Mapper(this SchoolEducationSubCourse SchoolEducationSubCourse)
        {
            var dto = new SchoolEducationSubCourseDto();

            if (SchoolEducationSubCourse != null)
            {
                dto.Id = SchoolEducationSubCourse.Id;
                dto.SchoolId = SchoolEducationSubCourse.SchoolId;
                dto.EducationSubCourseId = SchoolEducationSubCourse.EducationSubCourseId;
                dto.EducationSubCourseName = SchoolEducationSubCourse.EducationSubCourse.Name;
            }

            return dto;
        }
    }
}
