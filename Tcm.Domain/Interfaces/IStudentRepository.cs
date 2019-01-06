using Framework.Core;
using Framework.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Domain.Interfaces
{
   

    public interface IStudentRepository : IRepository<Student, long>
    {
    }

    public interface IClassRoomRepository : IRepository<ClassRoom,long>
    {
    }

    public interface  IClassStudentRepository: IRepository<ClassStudent,long>
    {
    }
    public interface  IEducationCourseRepository: IRepository<EducationCourse,short>
    {
    }
    public interface  IEducationLevelRepository: IRepository<EducationLevel,short>
    {
    }
    public interface  IEducationSubCourseRepository: IRepository<EducationSubCourse,short>
    {
    }
    public interface  IMajorRepository: IRepository<Major,short>
    {
    }

    public interface IPhoneNumberRepository : IRepository<PhoneNumber,long >
    {
    }
    public interface IProvinceRepository : IRepository<Province,short>
    {
    }
    public interface ISchoolRepository : IRepository<School,long>
    {
    }
    public interface ISchoolEducationSubCourseRepository : IRepository<SchoolEducationSubCourse,long>
    {
    }

    public interface ISchoolSubTypeRepository : IRepository<SchoolSubType,short>
    {
    }
    public interface ISchoolTypeRepository : IRepository<SchoolType,short>
    {
    }

    public interface ICityRepository : IRepository<City, int>
    {
    }


}
