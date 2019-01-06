using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class CityConfiguration :BaseConfiguration<City,int>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);
        }
    }
}
