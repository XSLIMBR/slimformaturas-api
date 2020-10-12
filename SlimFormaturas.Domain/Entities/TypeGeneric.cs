using SlimFormaturas.Domain.Dto.TypeGeneric.Enum;
using SlimFormaturas.Domain.Entities.Enums;
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
        public Location Localization { get; set; }

        public DateTime DateRegister { get; protected set; }

    }
}
