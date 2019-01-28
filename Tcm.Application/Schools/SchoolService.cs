using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Core;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
using Microsoft.EntityFrameworkCore;
using Tcm.Application.Contract.Schools;
using Tcm.Application.Contract.SchoolTypes;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.Schools
{
    public class SchoolService : ISchoolService
    {

        private ISchoolRepository _schoolRepository;
        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public void Add(SchoolDto School)
        {
            var school = new School()
            {
                Name = School.Name
            };
            _schoolRepository.Add(school);

        }

       
        public void Delete(int Id)
        {
            var school = Get(Id);
            if (school != null)
                _schoolRepository.Delete(school.Mapper());
        }

        public SchoolDto Get(int id)
        {
            return _schoolRepository.GetById(id).Mapper();
        }

        public List<SchoolDto> GetAll(UserParams userParams)
        {
            var items = _schoolRepository.GetAll()
                .Pager(userParams).Mapper();

            return items;

        }

        public List<SchoolDto> GetAll(Expression<Func<School, bool>> expression)
        {
            return _schoolRepository.GetAll(expression).ToList().Mapper();
        }

       

        public void Update(int Id, SchoolDto model)
        {
            var school = _schoolRepository.GetById(Id);

            if (school != null)
            {
                school.Name = model.Name;

                _schoolRepository.Update(school);
            }
        }

     

      
    }

    public static class SchoolMapper
    {
     
            public static List<SchoolDto> Mapper(this List<School> schools)
            {
                var items = new List<SchoolDto>();
                schools.ForEach(x => items.Add(x.Mapper()));
                return items;
            }

        public static List<SchoolDto> Mapper(this IQueryable<School> schools)
        {
            var items = schools.Select(x => new SchoolDto()
            {
                ProvinceName = x.City.Province.Name,
                SchoolTypeName = x.SchoolType.Name,
                CreationDate = x.CreationDate,
                Name = x.Name,
                FounderName = x.FounderName,
                ManagerName = x.ManagerName,
                PostalAddress = x.PostalAddress,
                PostalCode = x.PostalCode,
                PhoneNumber1 = x.PhoneNumber1,
                PhoneNumber2 = x.PhoneNumber2,
                RegisterStudentCount = x.TotalStudentCount,
                TotalStudentCount = x.TotalStudentCount,
                SchoolNumber = x.SchoolNumber,
                Sex = x.Sex,                
                ShiftType = x.ShiftType,
                EducationSubCourse = x.SchoolEducationSubCourses.FirstOrDefault().EducationSubCourse,
                WebUrl =x.WebUrl

            }).ToList();

            return items;
        }

        public static SchoolDto Mapper(this School school)
            {


                var dto = new SchoolDto();

                if (school != null)
                {

                }

                return dto;
            }
            public static List<School> Mapper(this List<SchoolDto> schools)
            {
                var items = new List<School>();
                schools.ForEach(x => items.Add(x.Mapper()));
                return items;
            }

            public static School Mapper(this SchoolDto school)
            {


                var dto = new School();

                if (school != null)
                {

                }

                return dto;
            }
        }
    }


