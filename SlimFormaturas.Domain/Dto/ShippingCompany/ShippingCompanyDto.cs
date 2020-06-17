using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Phone;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Dto.ShippingCompany {
    public class ShippingCompanyDto {
        public string ShippingCompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        #region Dados Bancarios
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion
        public DateTime DateRegister { get; set; }
        public virtual IList<AddressDto> Address { get; set; }
        public virtual IList<PhoneDto> Phone { get; set; }
    }
}
