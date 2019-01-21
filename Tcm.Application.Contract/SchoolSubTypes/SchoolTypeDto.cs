using System;
using System.Collections.Generic;
using System.Text;

namespace Tcm.Application.Contract.SchoolTypes
{
    public class SchoolSubTypeDto
    {
        public string Name { get; set; }

        public short Id { get; set; }

        public short SchoolTypeId { get; set; }

        public string SchoolTypeName { get; set; }

    }
}
