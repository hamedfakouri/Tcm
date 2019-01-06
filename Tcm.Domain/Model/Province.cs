using System;
using System.Collections.Generic;
using System.Text;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class Province : EntityBase<short>
    {

        public string Name { get; set; }

        public List<City> Cities { get; set; }

    }
}
