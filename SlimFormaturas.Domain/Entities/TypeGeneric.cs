using SlimFormaturas.Domain.Validators;
using System;

namespace SlimFormaturas.Domain.Entities {
    public class TypeGeneric : Entity{
        public TypeGeneric() {
            TypeGenericId = Guid.NewGuid().ToString();
        }

        public TypeGeneric(string typeGenericId, string name, Locate localization, DateTime dateRegister) {
            TypeGenericId = typeGenericId;
            Name = name;
            Localization = localization;
            DateRegister = dateRegister;
            Validate(this, new TypeGenericValidator());
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
