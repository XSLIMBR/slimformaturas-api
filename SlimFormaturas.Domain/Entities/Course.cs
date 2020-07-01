using System;
using System.Collections.Generic;

namespace SlimFormaturas.Domain.Entities {
    public class Course : Entity {
        public Course() {
            CourseId = Guid.NewGuid().ToString();
        }
        public string CourseId { get; set; }
        public string Name { get; set; }
        public virtual IList<ContractCourse> ContractCourses { get; set; }
        public virtual IList<GraduateCeremonial> GraduateCeremonial { get; set; }
    }
}
