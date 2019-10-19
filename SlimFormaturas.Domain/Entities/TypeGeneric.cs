using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class TypeGeneric {
        public TypeGeneric() {
            TypeGenericId = Guid.NewGuid().ToString();
        }
        public string TypeGenericId { get; set; }
        public string Name { get; set; }
        public locate localization { get; set; }

        public DateTime DateRegister { get; set; }
    }

    public enum locate {
        Address,
        Telephone
    }

}
