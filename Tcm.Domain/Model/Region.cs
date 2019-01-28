using System;
using System.Collections.Generic;
using System.Text;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class Region :EntityBase<int>
    {
        public string Name { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }

  

    }
}
