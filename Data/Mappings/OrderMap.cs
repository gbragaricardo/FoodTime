using FoodTime.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTime.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Tabela do banco
            builder.ToTable("Order");

            // Chave primaria
            builder.HasKey(o => o.Id);

            //Identity
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(o => o.CreationDate)
                .IsRequired()
                .HasColumnName("CreationDate")
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(o => o.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasConversion<string>() // Para converter e salvar como texto
                .HasMaxLength(16);

            builder.Property(o => o.TotalPrice)
                 .IsRequired()
                 .HasColumnName("TotalPrice")
                 .HasColumnType("decimal(18,2)")
                 .HasDefaultValue(0m);

            builder.Property(o => o.SubTotal)
                 .IsRequired()
                 .HasColumnName("SubTotal")
                 .HasColumnType("decimal(18,2)")
                 .HasDefaultValue(0m);

            //Relacionamentos

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .HasConstraintName("FK_Order_Customer")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Restaurant)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.RestaurantId)
                .HasConstraintName("FK_Order_Restaurant")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
