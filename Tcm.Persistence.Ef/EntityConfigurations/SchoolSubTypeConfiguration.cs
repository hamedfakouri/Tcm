using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class SchoolSubTypeConfiguration : BaseConfiguration<SchoolSubType, short>
    {
        public override void Configure(EntityTypeBuilder<SchoolSubType> builder)
        {
            base.Configure(builder);
        }
    }


}
