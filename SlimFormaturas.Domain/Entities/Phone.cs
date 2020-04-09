using System;
using System.Collections.Generic;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Phone : Entity{
        public Phone() {
        }

        public Phone(string ddd, string phoneNumber, TypeGeneric typeGeneric) {
            PhoneId = Guid.NewGuid().ToString();
            Ddd = ddd;
            PhoneNumber = phoneNumber;
            TypeGeneric = typeGeneric;
            Validate(this, new PhoneValidator());
        }

        public string PhoneId { get; private set; }
        public bool Default { get; set; }
        public string Ddd { get; set; }
        public string PhoneNumber { get; set; }

        public string TypeGenericId { get; set; }
        public string GraduateId { get; set;}
        public string CollegeId { get; set; }
        public string EmployeeId { get; set; }
        public string SellerId { get; set; }
        public string ShippingCompanyId { get; set; }


        public TypeGeneric TypeGeneric { get; set; }
        public Graduate Graduate { get; set; }
        public College College { get; set; }
        public Employee Employee { get; set; }
        public Seller Seller { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
    }
}
