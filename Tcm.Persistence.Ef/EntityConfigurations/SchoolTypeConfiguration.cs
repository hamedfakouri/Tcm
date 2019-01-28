using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class SchoolTypeConfiguration : BaseConfiguration<SchoolType, short>
    {
        public override void Configure(EntityTypeBuilder<SchoolType> builder)
        {
            base.Configure(builder);
        }
    }


}
