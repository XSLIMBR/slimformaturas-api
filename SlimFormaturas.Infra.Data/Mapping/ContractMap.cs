using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Infra.Data.Mapping
{
    public class ContractMap : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(c => c.ContractId);

            builder.Property(c => c.ContractId)
                .HasColumnName("Id");

            builder.Property(c => c.Code)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable("Contract");
        }
    }
}
