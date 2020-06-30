using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping {
    public class ContractCourseMap : IEntityTypeConfiguration<ContractCourse> {
        public void Configure(EntityTypeBuilder<ContractCourse> builder) {

            builder.HasKey(c => new { c.CourseId, c.ContractId });

            builder.HasOne(c => c.Contract)
                .WithMany(b => b.ContractCourses)
                .HasForeignKey(c => c.ContractId);

           
           builder.HasOne(c => c.Course)
                .WithMany(b => b.ContractCourse)
                .HasForeignKey(c => c.CourseId);
           
        }
    }
}
