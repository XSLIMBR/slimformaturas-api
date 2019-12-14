using System;
using System.Collections.Generic;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Phone : Entity{
        public Phone() {
            PhoneId = Guid.NewGuid().ToString();
        }

        public Phone(string phoneId, string ddd, string phoneNumber, string typeGenericId, string graduateId) {
            PhoneId = phoneId;
            Ddd = ddd;
            PhoneNumber = phoneNumber;
            TypeGenericId = typeGenericId;
            GraduateId = graduateId;
            Validate(this, new PhoneValidator());
        }

        public string PhoneId { get; private set; }
        public string Ddd { get; set; }
        public string PhoneNumber { get; set; }

        public string TypeGenericId { get; set; }
        public string GraduateId { get; set;}


        public virtual TypeGeneric TypeGeneric { get; private set; }
        public virtual Graduate Graduate { get; private set; }
    }
}
