using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class EducationSubCourseConfiguration : BaseConfiguration<EducationSubCourse, short>
    {
        public override void Configure(EntityTypeBuilder<EducationSubCourse> builder)
        {
            base.Configure(builder);
        }
    }


}
