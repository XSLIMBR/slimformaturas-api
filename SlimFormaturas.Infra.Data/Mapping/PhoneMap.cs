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

            builder.Property(u => u.TypeGenericId)
                .IsRequired();

            builder.Property(u => u.GraduateId)
                .IsRequired();

            builder.HasOne(c => c.Graduate)
                .WithMany(p => p.Phone);

            builder.HasOne(c => c.TypeGeneric);

            builder.ToTable("Phone");

        }
    }
}
