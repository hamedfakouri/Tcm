using System.Collections.Generic;
using System.Text;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class EducationYear : EntityBase<int>
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<ClassRoom> classRooms { get; set; }
    }
    
}
