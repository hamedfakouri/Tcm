using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class MajorConfiguration : BaseConfiguration<Major, short>
    {
        public override void Configure(EntityTypeBuilder<Major> builder)
        {
            base.Configure(builder);
        }
    }


}
