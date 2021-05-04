using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CabralStore.Vendas.Domain;

namespace CabralStore.Catalogo.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo)
                .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");

            // 1 : N => Pedido : PedidoItems
            builder.HasMany(c => c.PedidoItems)
                .WithOne(c => c.Pedido)
                .HasForeignKey(c => c.PedidoId);

            builder.Property(c => c.Desconto)
                .HasColumnType("decimal (10,2)");

            builder.Property(c => c.ValorTotal)
                .HasColumnType("decimal (10,2)");

            builder.ToTable("Pedidos");
        }
    }
}