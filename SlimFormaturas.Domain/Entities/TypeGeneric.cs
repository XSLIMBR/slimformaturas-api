using System;

namespace SlimFormaturas.Domain.Entities {
    public class TypeGeneric {
        public TypeGeneric() {
            TypeGenericId = Guid.NewGuid().ToString();
        }
        public string TypeGenericId { get; set; }
        public string Name { get; set; }
        public Locate Localization { get; set; }

        public DateTime DateRegister { get; set; }
    }

    public enum Locate {
        Address,
        Telephone
    }

}
