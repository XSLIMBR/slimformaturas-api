using System;
using System.Collections.Generic;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Phone : Entity{
        public Phone() {
            PhoneId = Guid.NewGuid().ToString();
        }

        public Phone(string phoneId, string ddd, string phoneNumber, TypeGeneric typeGeneric) {
            PhoneId = phoneId;
            Ddd = ddd;
            PhoneNumber = phoneNumber;
            TypeGeneric = typeGeneric;
            Validate(this, new PhoneValidator());
        }

        public string PhoneId { get; private set; }
        public string Ddd { get; set; }
        public string PhoneNumber { get; set; }

        public string TypeGenericId { get; set; }
        public string GraduateId { get; set;}


        public TypeGeneric TypeGeneric { get; set; }
        public Graduate Graduate { get; set; }
    }
}
