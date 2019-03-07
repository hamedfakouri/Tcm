using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Framework.Persistence.Ef;
using Framework.Persistence.Ef.Extensions;
using Microsoft.EntityFrameworkCore;
using Tcm.Application.Contract.ClassRooms;
using Tcm.Application.Contract.EducationLevels;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Application.ClassRooms
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public ClassRoomService(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }
        public void Add(ClassRoomAddDto classRoomAddDto)
        {
            var classRoom = new ClassRoom()
            {
                Name = classRoomAddDto.Name,
                SchoolEducationSubCourseId = classRoomAddDto.SchoolEducationSubCourseId,
                Year = classRoomAddDto.Year
            };

            _classRoomRepository.Add(classRoom);
        }

        public void Delete(short Id)
        {
            var classRoom = Get(Id);
            if (classRoom != null)
                _classRoomRepository.Delete(classRoom);
        }

        public ClassRoom Get(short id)
        {
            return _classRoomRepository.GetAll().FirstOrDefault(x => x.Id == id);

        }

        public List<ClassRoomDto> GetAll(UserParams userParams, int schoolId)
        {
            return _classRoomRepository.GetAll()
                .Include(x => x.SchoolEducationSubCourse.EducationSubCourse)
                .Include(x => x.SchoolEducationSubCourse.EducationSubCourse.EducationCourse)
                .Where(x => x.SchoolEducationSubCourse.SchoolId == schoolId)
                .Pager(userParams).ToList().Mapper();
        }

        public List<ClassRoom> GetAll(Expression<Func<ClassRoom, bool>> expression)
        {
            return _classRoomRepository.GetAll(expression).ToList();
        }

        public void Update(short Id, ClassRoomDto model)
        {
            var classRoom = _classRoomRepository.GetById(Id);

            if (classRoom != null)
            {
                classRoom.Name = model.Name;
                classRoom.SchoolEducationSubCourseId = model.SchoolEducationSubCourseId;
                classRoom.Year = model.Year;

                _classRoomRepository.Update(classRoom);
            }
        }
    }

    public static class ClassRoomMapper
    {
        public static List<ClassRoomDto> Mapper(this List<ClassRoom> classRooms)
        {
            var items = new List<ClassRoomDto>();
            classRooms.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static ClassRoomDto Mapper(this ClassRoom classRoom)
        {
            var dto = new ClassRoomDto();

            if (classRoom != null)
            {
                dto.Id = classRoom.Id;
                dto.Name = classRoom.Name;
                dto.SchoolEducationSubCourseId = classRoom.SchoolEducationSubCourseId;
                dto.EducationSubCourseName = classRoom.SchoolEducationSubCourse.EducationSubCourse.Name;
                dto.EducationCourseName = classRoom.SchoolEducationSubCourse.EducationSubCourse.EducationCourse.Name;
            }

            return dto;
        }
        public static List<ClassRoom> Mapper(this List<ClassRoomDto> classRoomDtos)
        {
            var items = new List<ClassRoom>();
            classRoomDtos.ForEach(x => items.Add(x.Mapper()));
            return items;
        }

        public static ClassRoom Mapper(this ClassRoomDto classRoomDto)
        {
            var dto = new ClassRoom();

            if (classRoomDto != null)
            {
                dto.Id = classRoomDto.Id;
                dto.Name = classRoomDto.Name;
                dto.SchoolEducationSubCourseId = classRoomDto.SchoolEducationSubCourseId;
            }

            return dto;
        }
    }

}
