using SlimFormaturas.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlimFormaturas.Domain.Entities {
    public class TypeGeneric : Entity {
        public TypeGeneric() {
            TypeGenericId = Guid.NewGuid().ToString();
        }

        public string TypeGenericId { get; set; }
        public string Name { get; set; }
        public Locate Localization { get; set; }

        public DateTime DateRegister { get; protected set; }

        public enum Locate {
            Address = 1,
            Telephone = 2
        }
    }
}
