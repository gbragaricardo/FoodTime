using FoodTime.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTime.Data.Mappings
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            {

                // Tabela do banco
                builder.ToTable("OrderProduct");

                // Chave primaria
                builder.HasKey(p => p.Id);

                //Identity
                builder.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                //Propriedades
                builder.Property(o => o.Quantity)
                    .IsRequired()
                    .HasColumnName("Quantity")
                    .HasColumnType("int")
                    .HasDefaultValue(0m);

                builder.Property(o => o.UnitPrice)
                    .IsRequired()
                    .HasColumnName("UnitPrice")
                    .HasColumnType("decimal(18,2)")
                    .HasDefaultValue(0m);

                //Relacionamentos

                builder.HasOne(op => op.Order)
                    .WithMany(o => o.OrderProducts)
                    .HasForeignKey(op => op.OrderId)
                    .HasConstraintName("FK_OrderProduct_Order")
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(op => op.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(op => op.ProductId)
                    .HasConstraintName("FK_OrderProduct_Product")
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}
