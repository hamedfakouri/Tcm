using System;
using System.Collections.Generic;
using System.Text;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class City :EntityBase<int>
    {
        public string Name { get; set; }
        public short ProvinceId { get; set; }

        public Province Province { get; set; }

        public List<School> Schools { get; set; }

    }
}
