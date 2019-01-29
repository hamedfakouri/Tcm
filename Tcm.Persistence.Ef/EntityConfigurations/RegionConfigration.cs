using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    
        public class RegionConfigration : BaseConfiguration<Region, int>
        {
            public override void Configure(EntityTypeBuilder<Region> builder)
            {
                base.Configure(builder);
            }
        
    }
}
