using System;
using System.Collections.Generic;
using System.Text;

namespace Tcm.Application.Contract.EducationLevels
{
   public class EducationLevelDto
    {
        public short Id { get; set; }

        public string Name { get; set; }
    }

    public class EducationLevelAddDto
    {
        public short Id { get; set; }

        public string Name { get; set; }
    }
}
