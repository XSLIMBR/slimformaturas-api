using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Infra.Data.Mapping {
    public class SellerMap : IEntityTypeConfiguration<Seller> {
        public void Configure (EntityTypeBuilder<Seller> builder) {
            builder.HasKey(c => c.SellerId);

            builder.Property(c => c.SellerId)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Rg)
                .IsRequired();

            builder.Property(c => c.Sex)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Photo)
                .HasColumnType("varchar")
                .HasMaxLength(255);

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

            builder.Property(c => c.UserId)
                .HasColumnType("nvarchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(c => c.DateRegister)
                .IsRequired();


            builder.ToTable("Seller");
        }
    }
}
