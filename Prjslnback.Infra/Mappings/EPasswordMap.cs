using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prjslnback.Domain.Entities;

namespace Prjslnback.Infra.Mappings
{
    public class EPasswordMap : IEntityTypeConfiguration<EPassword>
    {
        public void Configure(EntityTypeBuilder<EPassword> builder)
        {
            builder.ToTable("EPassword");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(1000)");
        }
    }
}
