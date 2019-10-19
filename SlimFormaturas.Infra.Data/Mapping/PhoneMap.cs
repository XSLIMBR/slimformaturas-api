using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping  {
    public class PhoneMap : IEntityTypeConfiguration<Phone> {
        public void Configure(EntityTypeBuilder<Phone> builder) {
            builder.HasKey(u => u.PhoneId);

            builder.Property(u => u.PhoneId)
                .HasColumnName("Id");

            builder.Property(u => u.Ddd)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired()
                .HasColumnName("DDD");

            builder.Property(u => u.PhoneNumber)
                .HasColumnType("varchar(9)")
                .HasMaxLength(9)
                .IsRequired()
                .HasColumnName("PhoneNumber");

            builder.ToTable("Phone");

        }
    }
}
