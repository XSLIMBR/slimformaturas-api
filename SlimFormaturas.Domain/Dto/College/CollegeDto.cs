using System;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Phone;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Dto.College {
    public class CollegeDto {

        public string CollegeId { get; set; }
        public string CorporateName { get; set; }
        public string FantasyName { get; set; }
        public string CNPJ { get; set; }
        #region ContaBancária
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion
        public string Email { get; set; }
        public string Site { get; set; }
        public DateTime DateRegister { get; protected set; }

        public IList<AddressDto> Address { get; set; }
        public IList<PhoneDto> Phone { get; set; }
        //public IList<ContractDto> Contract { get; set; }
    }
}