using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Phone;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Dto.ShippingCompany {
    public class ShippingCompanyForCreationDto {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        #region Dados Bancarios
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion
        public virtual IList<AddressForCreationDto> Address { get; set; }
        public virtual IList<PhoneForCreationDto> Phone { get; set; }
    }
}
