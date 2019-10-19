using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping {
    public class TypeGenericMap : IEntityTypeConfiguration<TypeGeneric> {
        public void Configure(EntityTypeBuilder<TypeGeneric> builder) {
            builder.HasKey(u => u.TypeGenericId);

            builder.Property(u => u.TypeGenericId)
                .HasColumnName("Id");

            builder.Property(u => u.Name)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Name");


            builder.ToTable("TypeGeneric");

        }
    }
}
