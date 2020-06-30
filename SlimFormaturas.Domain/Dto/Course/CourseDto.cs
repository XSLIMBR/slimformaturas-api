using SlimFormaturas.Domain.Entities;
using System.Collections.Generic;

namespace SlimFormaturas.Domain.Dto.Course
{
    public class CourseDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public IList<ContractCourse> ContractCourse { get; set; }
        public IList<GraduateCeremonial> GraduateCeremonial { get; set; }
    }
}
