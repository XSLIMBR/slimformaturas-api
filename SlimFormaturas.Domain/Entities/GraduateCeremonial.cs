using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class GraduateCeremonial : Entity{
        public GraduateCeremonial() {
            GraduateCeremonialId = Guid.NewGuid().ToString();
        }

        public GraduateCeremonial(string graduateCeremonialId, bool committee, string courseId) {
            GraduateCeremonialId = graduateCeremonialId;
            Committee = committee;
            CourseId = courseId;
        }

        public string GraduateCeremonialId { get; set;}
        public bool Committee { get; set; }

        public string GraduateId { get; set; }
        public string ContractId { get; set; }
        public string CourseId { get; set; }

        public Graduate Graduate { get; set; }
        public Contract Contract { get; set; }
        public Course Course { get; set; }
    }
}
