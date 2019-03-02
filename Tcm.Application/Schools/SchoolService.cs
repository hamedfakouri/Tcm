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
                RegionId = (School.RegionId == 0 ? null : School.RegionId),
                CreationDate = School.CreationDate,
                FounderName = School.FounderName,
                ManagerName = School.ManagerName,
                PhoneNumber1 = School.PhoneNumber1,
                PhoneNumber2 = School.PhoneNumber2,
                PostalAddress = School.PostalAddress,
                PostalCode = School.PostalCode,
                RegisterStudentCount = School.RegisterStudentCount,
                SchoolNumber = School.SchoolNumber,
                SchoolSubTypeId = (School.SchoolSubTypeId == 0 ? null : School.SchoolSubTypeId),
                SchoolTypeId = School.SchoolTypeId,
                Sex = School.Sex,
                ShiftType = School.ShiftType,
                TotalStudentCount = School.TotalStudentCount,
                WebUrl = School.WebUrl,
                EducationCourseId = School.EducationCourseId,
                SchoolEducationSubCourses = School.SchoolEducationSubCourses
            };
            _schoolRepository.Add(school);

            if(school.Id != 0 && school.SchoolEducationSubCourses != null)
            {
                //ToDO: Save School Education Sub Course
            }

        }


        public void Delete(int Id)
        {
            var school = Get(Id);
            if (school != null)
                _schoolRepository.Delete(school.Mapper());
        }

        public SchoolDto Get(int id)
        {
            return _schoolRepository.GetAll(x=> x.Id == id).Include(x=> x.City).Include(x=> x.EducationCourse)
                .Include(x => x.SchoolEducationSubCourses).FirstOrDefault().Mapper();
        }

        public List<SchoolDto> GetAll(UserParams userParams)
        {
            var items = _schoolRepository.GetAll()
                .Pager(userParams).Mapper();

            return items;

        }

        public List<SchoolDto> GetAll(Expression<Func<School, bool>> expression)
        {
            return _schoolRepository.GetAll(expression).Include(x=> x.City).Include(x => x.EducationCourse).ToList().Mapper();
        }



        public void Update(int Id, SchoolDto model)
        {
            var school = _schoolRepository.GetById(Id);

            if (school != null)
            {
                school.Name = model.Name;
                school.CityId = model.CityId;
                school.RegionId = (model.RegionId == 0 ? null: model.RegionId);
                school.CreationDate = model.CreationDate;
                school.FounderName = model.FounderName;
                school.ManagerName = model.ManagerName;
                school.PhoneNumber1 = model.PhoneNumber1;
                school.PhoneNumber2 = model.PhoneNumber2;
                school.PostalAddress = model.PostalAddress;
                school.PostalCode = model.PostalCode;
                school.RegisterStudentCount = model.RegisterStudentCount;
                school.SchoolNumber = model.SchoolNumber;
                school.SchoolTypeId = model.SchoolTypeId;
                school.SchoolSubTypeId = (model.SchoolSubTypeId == 0 ? null : model.SchoolSubTypeId);
                school.Sex = model.Sex;
                school.ShiftType = model.ShiftType;
                school.TotalStudentCount = model.TotalStudentCount;
                school.WebUrl = model.WebUrl;
                school.EducationCourseId = model.EducationCourseId;
                school.SchoolEducationSubCourses = model.SchoolEducationSubCourses;

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
                Name = x.Name,
                CityName = x.City.Name,
                ProvinceName = x.City.Province.Name,
                SchoolTypeName = x.SchoolType.Name,
                CreationDate = x.CreationDate,
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
                WebUrl = x.WebUrl

            }).ToList();

            return items;
        }

        public static SchoolDto Mapper(this School school)
        {
            var dto = new SchoolDto();

            if (school != null)
            {
                dto = new SchoolDto()
                {
                    Id = school.Id,
                    CityId = school.CityId,
                    ProvinceId = school.City?.ProvinceId,
                    RegionId = school.RegionId,
                    SchoolTypeId = school.SchoolTypeId,
                    SchoolSubTypeId = school.SchoolSubTypeId,
                    CreationDate = school.CreationDate,
                    Name = school.Name,
                    FounderName = school.FounderName,
                    ManagerName = school.ManagerName,
                    PostalAddress = school.PostalAddress,
                    PostalCode = school.PostalCode,
                    PhoneNumber1 = school.PhoneNumber1,
                    PhoneNumber2 = school.PhoneNumber2,
                    RegisterStudentCount = school.TotalStudentCount,
                    TotalStudentCount = school.TotalStudentCount,
                    SchoolNumber = school.SchoolNumber,
                    Sex = school.Sex,
                    ShiftType = school.ShiftType,
                    SchoolEducationSubCourses = school.SchoolEducationSubCourses?.ToList(),
                    WebUrl = school.WebUrl,
                    EducationCourseId = school.EducationCourseId,
                    EducationLevelId = school.EducationCourse.EducationLevelId,
                    
                };
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
            }

            return dto;
        }
    }
}


