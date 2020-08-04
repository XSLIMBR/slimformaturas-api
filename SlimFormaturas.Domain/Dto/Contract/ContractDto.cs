using SlimFormaturas.Domain.Dto.College;

namespace SlimFormaturas.Domain.Dto.Contract {
    public class ContractDto {
        public string ContractId { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
        public string CollegeName { get; set; }
    }
}