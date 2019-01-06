using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class ClassStudentConfiguration : IEntityTypeConfiguration<ClassStudent>
    {
        

        public void Configure(EntityTypeBuilder<ClassStudent> builder)
        {
           
            builder.HasKey(x =>  new { x.ClassRoomId,x.StudentId});
            builder.HasOne(x => x.ClassRoom).WithMany(x => x.ClassStudents).HasForeignKey(x => x.ClassRoomId);
            builder.HasOne(x => x.Student).WithMany(x => x.ClassStudents).HasForeignKey(x => x.StudentId);
        }
    }
}
