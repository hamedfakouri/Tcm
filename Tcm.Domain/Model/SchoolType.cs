using System.Collections.Generic;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class SchoolType : EntityBase<short>
    {
        public string Name { get; set; }

        public List<School> Schools { get; set; }
    }
    
}
