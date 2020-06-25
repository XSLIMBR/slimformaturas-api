using System;

namespace SlimFormaturas.Domain.Entities {
    public class ContractCourse {
        public ContractCourse() {
            ContractId = Guid.NewGuid().ToString();
        }
        public string ContractId { get; set; }
        public Contract Contract { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
    }
}
