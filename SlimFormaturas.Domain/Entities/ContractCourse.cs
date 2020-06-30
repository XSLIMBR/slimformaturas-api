using System;

namespace SlimFormaturas.Domain.Entities {
    public class ContractCourse {

       public ContractCourse()
        {
            ContractCourseId = Guid.NewGuid().ToString();
        }

        public string ContractCourseId { get; set; }

        //Contract
        public string ContractId { get; set; }
        public Contract Contract { get; set; }

        //Curso
        public string CourseId { get; set; }
        public Course Course { get; set; }
    }
}
