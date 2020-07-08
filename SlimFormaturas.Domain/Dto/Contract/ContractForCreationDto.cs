namespace SlimFormaturas.Domain.Dto.Contract
{
    public class ContractForCreationDto
    {
        public string Code { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }

        public string Note { get; set; }
    }
}
