using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class BaseConfiguration<T,Tkey> : IEntityTypeConfiguration<T> where T:EntityBase<Tkey>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            var name = typeof(T).Name+"sequence";
            builder.Property(x => x.Id).ForSqlServerUseSequenceHiLo(name);
            builder.HasKey(x => x.Id);
        }
    }

    public class ClassRoomConfiguration : BaseConfiguration<ClassRoom, long>
    {
        public override void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            base.Configure(builder);
        }
    }

    public class EducationCourseConfiguration : BaseConfiguration<EducationCourse, short>
    {
        public override void Configure(EntityTypeBuilder<EducationCourse> builder)
        {
            base.Configure(builder);
        }
    }

    public class EducationSubCourseConfiguration : BaseConfiguration<EducationSubCourse, short>
    {
        public override void Configure(EntityTypeBuilder<EducationSubCourse> builder)
        {
            base.Configure(builder);
        }
    }

    public class MajorConfiguration : BaseConfiguration<Major, short>
    {
        public override void Configure(EntityTypeBuilder<Major> builder)
        {
            base.Configure(builder);
        }
    }

    public class PhoneNumberConfiguration : BaseConfiguration<PhoneNumber, long>
    {
        public override void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            base.Configure(builder);
        }
    }

    public class SchoolConfiguration : BaseConfiguration<School, int>
    {
        public override void Configure(EntityTypeBuilder<School> builder)
        {
            base.Configure(builder);
        }
    }

    public class SchoolSubTypeConfiguration : BaseConfiguration<SchoolSubType, short>
    {
        public override void Configure(EntityTypeBuilder<SchoolSubType> builder)
        {
            base.Configure(builder);
        }
    }

    public class SchoolTypeConfiguration : BaseConfiguration<SchoolType, short>
    {
        public override void Configure(EntityTypeBuilder<SchoolType> builder)
        {
            base.Configure(builder);
        }
    }

    public class StudentConfiguration : BaseConfiguration<Student, long>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);
        }
    }

    public class EducationLevelConfiguration : BaseConfiguration<EducationLevel, short>
    {
        public override void Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            base.Configure(builder);
        }
    }


}
