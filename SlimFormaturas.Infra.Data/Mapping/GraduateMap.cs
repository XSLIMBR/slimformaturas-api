using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping {
    public class GraduateMap : IEntityTypeConfiguration<Graduate> {
        public void Configure(EntityTypeBuilder<Graduate> builder) {
            builder.HasKey(c => c.GraduateId);

            builder.Property(c => c.GraduateId)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable("Graduate");
        }
    }
}
