using System.Collections.Generic;
using System.Text;
using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class EducationLevel : EntityBase<short>
    {
        public string Name { get; set; }
        public List<EducationCourse> EducationCourses { get; set; }
    }
    
}
