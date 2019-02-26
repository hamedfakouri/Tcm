using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.IdentityModel;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role() {Id=1, Name = "Manager", NormalizedName = "MANAGER",Title="مدیر" }, new Role() {Id=2, Name = "Student", NormalizedName = "STUDENT",Title="دانش آموز" });
        }
    }
}
