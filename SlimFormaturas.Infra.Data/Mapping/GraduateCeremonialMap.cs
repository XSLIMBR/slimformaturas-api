using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping
{
    public class GraduateCeremonialMap : IEntityTypeConfiguration<GraduateCeremonial>
    {
        public void Configure(EntityTypeBuilder<GraduateCeremonial> builder)
        {
            builder.HasKey(c => new { c.GraduateId, c.CourseId });
        }
    }
}
