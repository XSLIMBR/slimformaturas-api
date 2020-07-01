using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class GraduateCeremonial : Entity{
        public GraduateCeremonial() {
            GraduateCeremonialId = Guid.NewGuid().ToString();

        }

        public string GraduateCeremonialId { get; set;}
        public bool Committee { get; set; }

        //Contract
        public Contract Contract { get; set; }
        public string ContractId { get; set; }

        //Graduate
        public string GraduateId { get; set; }
        public Graduate Graduate { get; set; }
      
        //Course
        public string CourseId { get; set; }
        public Course Course { get; set; }
    }
}
