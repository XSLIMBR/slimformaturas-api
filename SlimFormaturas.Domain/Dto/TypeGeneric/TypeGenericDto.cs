using SlimFormaturas.Domain.Dto.TypeGeneric.Enum;

namespace SlimFormaturas.Domain.Dto.TypeGeneric {
    public class TypeGenericDto {
        public string TypeGenericId { get; set; }
        public string Name { get; set; }
        public LocationDto Localization { get; set; }
    }
}
