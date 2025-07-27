using Invoice.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Data.Mappings
{
    public class FaturaItemMapping : IEntityTypeConfiguration<FaturaItem>
    {
        public void Configure(EntityTypeBuilder<FaturaItem> builder)
        {
            builder.HasKey(fi => fi.FaturaItemId);

            builder.Property(fi => fi.Ordem)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(fi => fi.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(fi => fi.ValorAprovado)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(fi => fi.Descricao)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.ToTable("FaturaItem");
        }
    }
}
