namespace SlimFormaturas.Domain.Dto.Contract {
    public class ContractDto {
        public string ContractId { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }

        //public College College { get; set; }
        //public IList<ContractCourse> ContractCourses { get; set; }
        //public IList<GraduateAlbum> GraduateAlbum { get; set; }
        //public IList<GraduateCeremonial> GraduateCeremonial { get; set; }
    }
}