using Invoice.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Data.Mappings
{
    public class FaturaMapping : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.HasKey(f => f.FaturaId);

            builder.Property(f => f.Cliente)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Data)
                .IsRequired()
                .HasColumnType("datetime");

            // 1: N
            builder.HasMany(f => f.FaturaItem)
                .WithOne(fi => fi.Fatura)
                .HasForeignKey(fi => fi.FaturaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Fatura");
        }
    }
}
