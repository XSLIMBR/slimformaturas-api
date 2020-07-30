using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping {
    public class GraduateCeremonialMap : IEntityTypeConfiguration<GraduateCeremonial> {
        public void Configure(EntityTypeBuilder<GraduateCeremonial> builder) {
            builder.HasKey(c => c.GraduateCeremonialId);

            builder.Property(c => c.GraduateCeremonialId)
                .HasColumnName("Id");

            builder.Property(c => c.Committee)
                .IsRequired();

            builder.HasOne(c => c.Course)
                .WithMany(p => p.GraduateCeremonial)
                .HasForeignKey(y => y.GraduateCeremonialId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(c => c.Graduate)
                .WithMany(p => p.GraduateCeremonial)
                .HasForeignKey(y => y.GraduateCeremonialId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(c => c.Contract)
                .WithMany(p => p.GraduateCeremonial)
                .HasForeignKey(y => y.GraduateCeremonialId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.ToTable("GraduateCeremonial");
        }
    }
}
