using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class Phone {
        public Phone() {
            PhoneId = Guid.NewGuid().ToString();
        }
        public string PhoneId { get; set; }
        public string Ddd { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Graduate Graduate { get; set; }
    }
}
