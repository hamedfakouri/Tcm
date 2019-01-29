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
                Name = School.Name,
                CityId = School.CityId,
                CreationDate = School.CreationDate,
                FounderName = School.FounderName,
                ManagerName = School.ManagerName,
                PhoneNumber1 = School.PhoneNumber1,
                PhoneNumber2 = School.PhoneNumber2,
                PostalAddress = School.PostalAddress,
                PostalCode = School.PostalCode,
                Region = School.Region,
                RegisterStudentCount = School.RegisterStudentCount,
                SchoolNumber = School.SchoolNumber,
                SchoolSubTypeId = School.SchoolSubTypeId,
                SchoolTypeId = School.SchoolTypeId,
                Sex = School.Sex,
                ShiftType = School.ShiftType,
                TotalStudentCount = School.TotalStudentCount,
                WebUrl = School.WebUrl,

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
                school.CityId = model.CityId;
                school.CreationDate = model.CreationDate;
                school.FounderName = model.FounderName;
                school.ManagerName = model.ManagerName;
                school.PhoneNumber1 = model.PhoneNumber1;
                school.PhoneNumber2 = model.PhoneNumber2;
                school.PostalAddress = model.PostalAddress;
                school.PostalCode = model.PostalCode;
                school.Region = model.Region;
                school.RegisterStudentCount = model.RegisterStudentCount;
                school.SchoolNumber = model.SchoolNumber;
                school.SchoolSubTypeId = model.SchoolSubTypeId;
                school.SchoolTypeId = model.SchoolTypeId;
                school.Sex = model.Sex;
                school.ShiftType = model.ShiftType;
                school.TotalStudentCount = model.TotalStudentCount;
                school.WebUrl = model.WebUrl;

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
                Id = x.Id,
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
                WebUrl = x.WebUrl

            }).ToList();

            return items;
        }

        public static SchoolDto Mapper(this School school)
        {


            var dto = new SchoolDto();

            if (school != null)
            {
                dto.Id = school.Id;
                dto.ProvinceName = school.City?.Province.Name;
                dto.SchoolTypeName = school.SchoolType?.Name;
                dto.CreationDate = school.CreationDate;
                dto.Name = school.Name;
                dto.FounderName = school.FounderName;
                dto.ManagerName = school.ManagerName;
                dto.PostalAddress = school.PostalAddress;
                dto.PostalCode = school.PostalCode;
                dto.PhoneNumber1 = school.PhoneNumber1;
                dto.PhoneNumber2 = school.PhoneNumber2;
                dto.RegisterStudentCount = school.TotalStudentCount;
                dto.TotalStudentCount = school.TotalStudentCount;
                dto.SchoolNumber = school.SchoolNumber;
                dto.Sex = school.Sex;
                dto.ShiftType = school.ShiftType;
                dto.EducationSubCourse = school.SchoolEducationSubCourses?.FirstOrDefault().EducationSubCourse;
                dto.WebUrl = school.WebUrl;
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
                dto.Id = school.Id;
                //dto.CreationDate = school.CreationDate;
                //dto.Name = school.Name;
                //dto.FounderName = school.FounderName;
                //dto.ManagerName = school.ManagerName;
                //dto.PostalAddress = school.PostalAddress;
                //dto.PostalCode = school.PostalCode;
                //dto.PhoneNumber1 = school.PhoneNumber1;
                //dto.PhoneNumber2 = school.PhoneNumber2;
                //dto.RegisterStudentCount = school.TotalStudentCount;
                //dto.TotalStudentCount = school.TotalStudentCount;
                //dto.SchoolNumber = school.SchoolNumber;
                //dto.Sex = school.Sex;
                //dto.ShiftType = school.ShiftType;
                //dto.WebUrl = school.WebUrl;
            }

            return dto;
        }
    }
}


