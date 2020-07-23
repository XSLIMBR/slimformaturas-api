using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Dto.Graduate {
    public class GraduateSearch {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string DadName { get; set; }
        public string MotherName { get; set; }
        public string Email { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
