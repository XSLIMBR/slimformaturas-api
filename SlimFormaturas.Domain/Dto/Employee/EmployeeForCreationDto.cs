using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Phone;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Dto.Employee {
    public class EmployeeForCreationDto {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string DadName { get; set; }
        public string MotherName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        #region ContaBancária
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion
        public DateTime DateRegister { get; protected set; }

        public IList<AddressForCreationDto> Address { get; set; }
        public IList<PhoneForCreationDto> Phone { get; set; }
    }
}
