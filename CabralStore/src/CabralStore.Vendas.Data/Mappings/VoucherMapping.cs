using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CabralStore.Vendas.Domain;

namespace CabralStore.Catalogo.Data.Mappings
{
    public class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Percentual)
                .HasColumnType("decimal (10,2)");

            builder.Property(c => c.ValorDesconto)
                .HasColumnType("decimal (10,2)");

            // 1 : N => Voucher : Pedidos
            builder.HasMany(c => c.Pedidos)
                .WithOne(c => c.Voucher)
                .HasForeignKey(c => c.VoucherId);

            builder.ToTable("Vouchers");
        }
    }
}