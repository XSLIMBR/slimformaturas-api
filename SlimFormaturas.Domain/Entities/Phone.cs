using System;
using System.Collections.Generic;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Phone : Entity{
        public Phone() {
            PhoneId = Guid.NewGuid().ToString();
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


        public virtual TypeGeneric TypeGeneric { get; set; }
        public virtual Graduate Graduate { get; set; }
        public virtual College College { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual ShippingCompany ShippingCompany { get; set; }
    }
}
