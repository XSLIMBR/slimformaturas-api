using System;
using System.Collections.Generic;
using System.Text;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Course : Entity {
        public Course() {
            CourseId = Guid.NewGuid().ToString();
        }

        public string CourseId { get; set; }
        public string Name { get; set; }
        public  IList<ContractCourse> ContractCourse { get; set; }
        public  IList<GraduateCeremonial> GraduateCeremonial { get; set; }
    }
}
