using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Infra.Data.Mapping {
    class ShippingCompanyMap : IEntityTypeConfiguration<ShippingCompany> {
        public void Configure (EntityTypeBuilder<ShippingCompany> builder) {
            builder.HasKey(c => c.ShippingCompanyId);

            builder.Property(c => c.ShippingCompanyId)
                .HasColumnName("Id");

            builder.Property(c => c.Site)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Bank)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Agency)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.CheckingAccount)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.DateRegister)
                .IsRequired();


            builder.ToTable("ShippingCompany");
        }
    }
}
