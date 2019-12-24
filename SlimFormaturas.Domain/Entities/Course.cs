using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities
{
    public class Course : Entity
    {
        public string CourseId { get; set; }
        public string Name { get; set; }

        public string ContractId { get; set; }

        public Contract Contract { get; set; }
    }
}
