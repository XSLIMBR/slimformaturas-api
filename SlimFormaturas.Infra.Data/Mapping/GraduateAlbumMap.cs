using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping
{
    public class GraduateAlbumMap : IEntityTypeConfiguration<GraduateAlbum>
    {
        public void Configure(EntityTypeBuilder<GraduateAlbum> builder)
        {
            builder.HasKey(c => c.GraduateAlbumId);

            builder.Property(c => c.GraduateAlbumId)
                .HasColumnName("Id");

            builder.Property(c => c.AlbumCode)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(c => c.Graduate)
                    .WithMany(p => p.GraduateAlbum)
                    .HasForeignKey(y => y.GraduateAlbumId)
                    .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(c => c.Contract)
                .WithMany(p => p.GraduateAlbum)
                .HasForeignKey(y => y.GraduateAlbumId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.ToTable("GraduateAlbum");
        }
    }
}
