using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Graduate {

        public Graduate(){
            GraduateId = Guid.NewGuid().ToString();
            
        }
        public string GraduateId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public bool Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string DadName { get; set; }
        public string MotherName { get; set; }
        public bool Committee { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        #region ContaBancária
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion

        public string UserId { get; set; }

        public DateTime DateRegister { get; set; }

        public virtual User User { get; set; }
        public virtual IList<Address> Address { get; set; }
        public virtual IList<Phone> Phone { get; set; }
    }
}
