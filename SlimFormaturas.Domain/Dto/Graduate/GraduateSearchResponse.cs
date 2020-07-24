using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Dto.Graduate {
    public class GraduateSearchResponse {
        public string GraduateId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
    }
}
