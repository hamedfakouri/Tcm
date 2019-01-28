using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class SchoolConfiguration : BaseConfiguration<School, int>
    {
        public override void Configure(EntityTypeBuilder<School> builder)
        {
            base.Configure(builder);
        }
    }


}
