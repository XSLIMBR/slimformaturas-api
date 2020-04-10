using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Dto.TypeGeneric {
    public class TypeGenericForCreationDto {
        public string Name { get; set; }
        public LocateForCreationDto Localization { get; set; }
        public enum LocateForCreationDto {
            Address = 1,
            Telephone = 2
        }
    }
}
