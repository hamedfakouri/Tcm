using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class ClassRoomConfiguration : BaseConfiguration<ClassRoom, long>
    {
        public override void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            base.Configure(builder);
        }
    }


}
