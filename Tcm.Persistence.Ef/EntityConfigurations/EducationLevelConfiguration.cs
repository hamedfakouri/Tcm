using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class EducationLevelConfiguration : BaseConfiguration<EducationLevel, short>
    {
        public override void Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.EducationCourses)
                .WithOne(x => x.EducationLevel)
                .OnDelete(DeleteBehavior.Restrict);
           
        }
    }


}
