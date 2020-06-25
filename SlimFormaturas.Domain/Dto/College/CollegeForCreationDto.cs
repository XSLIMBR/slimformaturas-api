using System;
using System.Collections.Generic;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Dto.College {
    public class CollegeForCreationDto {
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

        public IList<AddressForCreationDto> Address { get; set; }
        public IList<PhoneForCreationDto> Phone { get; set; }
    }
}