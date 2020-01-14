using System;
using System.Collections.Generic;
using System.Text;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Course : Entity {
        public Course() {
            CourseId = Guid.NewGuid().ToString();
        }
        public Course(string courseId, string name) {
            CourseId = courseId;
            Name = name;
            Validate(this, new CourseValidator());
        }
        public string CourseId { get; set; }
        public string Name { get; set; }

        public IList<ContractCourse> ContractCourses { get; set; }
        public IList<GraduateCeremonial> GraduateCeremonial { get; set; }
    }
}
