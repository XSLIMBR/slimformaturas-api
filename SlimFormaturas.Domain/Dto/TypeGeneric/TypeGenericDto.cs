namespace SlimFormaturas.Domain.Dto.TypeGeneric {
    public class TypeGenericDto {
        public string TypeGenericId { get; set; }
        public string Name { get; set; }
        public LocateDto Localization { get; set; }
        public enum LocateDto {
            Address = 1,
            Telephone = 2
        }
    }
}
