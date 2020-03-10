using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SlimFormaturas.Domain.Dto
{
    public class GraduateDto
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string DadName { get; set; }
        public string MotherName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        public IList<Address> Address { get; set; }
        public IList<Phone> Phone { get; set; }
    }
}