using System;
using System.Collections.Generic;
using System.Text;
using SlimFormaturas.Domain.Dto;

namespace SlimFormaturas.Domain.Dto.Address  {
    public class AddressForCreationDto {
        public bool Default { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
        public string TypeGenericId { get; set; }
    }
}