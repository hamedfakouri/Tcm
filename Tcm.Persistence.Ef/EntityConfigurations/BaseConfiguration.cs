using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class BaseConfiguration<T,Tkey> : IEntityTypeConfiguration<T> where T:EntityBase<Tkey>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            var name = typeof(T).Name+"sequence";
            builder.Property(x => x.Id).ForSqlServerUseSequenceHiLo(name);
            builder.HasKey(x => x.Id);
        }
    }


}
