using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class EducationCourseConfiguration : BaseConfiguration<EducationCourse, short>
    {
        public override void Configure(EntityTypeBuilder<EducationCourse> builder)
        {
            base.Configure(builder);
                       
        }
    }



}
