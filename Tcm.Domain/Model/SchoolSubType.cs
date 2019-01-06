using Framework.Persistence.Ef;
using System.Collections.Generic;

namespace Tcm.Domain.Model
{
    public class SchoolSubType : EntityBase<short>
    {
        public string Name { get; set; }
        /// <summary>
        /// if school type is null then this record is common in both school type
        /// </summary>
        public short? SchoolTypeId { get; set; }
        public SchoolType SchoolType { get; set; }

        public List<School> Schools  { get; set; }
    }
    
}
