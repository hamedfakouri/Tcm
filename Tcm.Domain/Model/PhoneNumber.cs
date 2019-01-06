using Framework.Persistence.Ef;
using Tcm.Domain.Enum;

namespace Tcm.Domain.Model
{
    public class PhoneNumber : EntityBase<long>
    {
        public string Phone { get; set; }
        public PhoneType PhoneType { get; set; }
        
        public long? SchoolId { get; set; }
        public School School { get; set; }
    }
    
}
