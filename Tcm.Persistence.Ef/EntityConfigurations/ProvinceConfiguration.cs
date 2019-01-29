using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class ProvinceConfiguration:BaseConfiguration<Province,short>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            base.Configure(builder);
           
        }
    }
}
