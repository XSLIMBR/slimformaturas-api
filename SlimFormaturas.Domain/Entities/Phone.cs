using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class Phone {
        public Phone() {
            PhoneId = Guid.NewGuid().ToString();
        }

        public Phone(string phoneId, string ddd, string phoneNumber, string graduateId) {
            PhoneId = phoneId;
            Ddd = ddd;
            PhoneNumber = phoneNumber;
            GraduateId = graduateId;
            //add validation
        }

        public string PhoneId { get; private set; }
        public string Ddd { get; set; }
        public string PhoneNumber { get; set; }

        public string GraduateId { get; private set;}

        public virtual Graduate Graduate { get; protected set; }
    }
}
