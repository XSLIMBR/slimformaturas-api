using System;
using System.Collections.Generic;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Contract : Entity {
        public Contract() {
            ContractId = Guid.NewGuid().ToString();
        }
        public Contract(string contractId, string code, int semester, int year, string note) {
            ContractId = contractId;
            Code = code;
            Semester = semester;
            Year = year;
            Note = note;
            ContractCourses = new List<ContractCourse>();
            Validate(this, new ContractValidator());
        }
        public string ContractId { get; set; }
        public string Code { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
        //RESPOSAVEL PELO CONTRATO
        //QUEM FECHOU O CONTRATO
        //RESPONSÁVEL CERIMONIAL
        public string Note { get; set; }

        public DateTime DateRegister { get; protected set; }

        public string CollegeId { get; set; }

        public College College { get; set; }
        public IList<ContractCourse> ContractCourses { get; set; }
        public IList<GraduateAlbum> GraduateAlbum { get; set; }
        public IList<GraduateCeremonial> GraduateCeremonial { get; set; }
    }
}
