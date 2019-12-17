using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping {
    public class AddressMap : IEntityTypeConfiguration<Address> {
        public void Configure(EntityTypeBuilder<Address> builder) {
            builder.HasKey(u => u.AddressId);

            builder.Property(u => u.AddressId)
                .HasColumnName("Id");

            builder.Property(u => u.Cep)
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(u => u.Street)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Number)
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(u => u.Complement)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(u => u.Neighborhood)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.City)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Uf)
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(u => u.TypeGenericId)
                .IsRequired();

            builder.HasOne(c => c.Graduate)
                .WithMany(p => p.Address)
                .HasForeignKey(y => y.GraduateId);

            builder.ToTable("Address");
        }
    }
}
