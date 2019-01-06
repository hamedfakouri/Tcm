using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class SchoolEducationSubCourseConfiguration : IEntityTypeConfiguration<SchoolEducationSubCourse>
    {
        public void Configure(EntityTypeBuilder<SchoolEducationSubCourse> builder)
        {
            builder.HasKey(x => new { x.EducationSubCourseId, x.MajorId, x.SchoolId });
            builder.HasOne(x => x.School).WithMany(x => x.SchoolEducationSubCourses).HasForeignKey(x => x.SchoolId);
            builder.HasOne(x => x.Major).WithMany(x => x.SchoolEducationSubCourses).HasForeignKey(x => x.MajorId);
            builder.HasOne(x => x.EducationSubCourse).WithMany(x => x.SchoolEducationSubCourses).HasForeignKey(x => x.EducationSubCourseId);
        }
    }
}
