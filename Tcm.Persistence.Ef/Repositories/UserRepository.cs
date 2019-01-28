using System;
using System.Collections.Generic;
using System.Text;
using Framework.Persistence.Ef;
using Tcm.Domain.Interfaces;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.Repositories
{
    public class UserRepository : BaseRepository<User, long>, IUserRepository
    {
        public UserRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }

    public class CityRepository : BaseRepository<City,int>, ICityRepository
    {
        public CityRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }

    public class ClassRoomRepository : BaseRepository<ClassRoom, long>, IClassRoomRepository
    {
        public ClassRoomRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }

    public class ClassStudentRepository : BaseRepository<ClassStudent,long>, IClassStudentRepository
    {
        public ClassStudentRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
    public class EducationCourseRepository : BaseRepository<EducationCourse,short>, IEducationCourseRepository
    {
        public EducationCourseRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
    public class EducationLevelRepository : BaseRepository<EducationLevel,short>, IEducationLevelRepository
    {
        public EducationLevelRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
    public class EducationSubCourseRepository : BaseRepository<EducationSubCourse,short>, IEducationSubCourseRepository
    {
        public EducationSubCourseRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
    public class MajorRepository : BaseRepository<Major,short>, IMajorRepository
    {
        public MajorRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
   
    public class ProvinceRepository : BaseRepository<Province,short>, IProvinceRepository
    {
        public ProvinceRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
    public class SchoolRepository : BaseRepository<School,int>, ISchoolRepository
    {
        public SchoolRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
    public class SchoolEducationSubCourseRepository : BaseRepository<SchoolEducationSubCourse,long>, ISchoolEducationSubCourseRepository
    {
        public SchoolEducationSubCourseRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
    public class SchoolSubTypeRepository : BaseRepository<SchoolSubType,short>, ISchoolSubTypeRepository
    {
        public SchoolSubTypeRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
    public class SchoolTypeRepository : BaseRepository<SchoolType,short>, ISchoolTypeRepository
    {
        public SchoolTypeRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }
    public class StudentRepository : BaseRepository<Student,long>, IStudentRepository
    {
        public StudentRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }

    public class RegionRepository : BaseRepository<Region, int>, IRegionRepository
    {
        public RegionRepository(TcmContext tcmContext) : base(tcmContext)
        {
        }
    }



}
