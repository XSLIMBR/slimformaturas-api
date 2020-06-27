using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Infra.Data.Mapping {
    class CollegeMap : IEntityTypeConfiguration<College> {
        public void Configure (EntityTypeBuilder<College> builder) {
            builder.HasKey(c => c.CollegeId);

            builder.Property(c => c.CollegeId)
                .HasColumnName("Id");

            builder.Property(c => c.CorporateName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.FantasyName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.CNPJ)
                .HasColumnType("varchar(14)")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(c => c.Site)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Bank)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.Agency)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.CheckingAccount)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.DateRegister)
                .IsRequired();

            builder.ToTable("College");
        }
    }
}
