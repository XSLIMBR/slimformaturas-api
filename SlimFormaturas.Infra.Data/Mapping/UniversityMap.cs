using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping
{
    public class UniversityMap : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder) 
        {
            builder.HasKey(c => c.UniversityId);

            builder.Property(c => c.UniversityId)
               .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable("University");
        }
    }
}
