using FoodTime.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTime.Data.Mappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Tabela do banco
            builder.ToTable("Payment");

            // Chave primaria
            builder.HasKey(p => p.Id);

            //Identity
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(p => p.Value)
                 .IsRequired()
                 .HasColumnName("Value")
                 .HasColumnType("decimal(18,2)")
                 .HasDefaultValue(0m);

            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasConversion<string>() // Para converter e salvar como texto
                .HasMaxLength(16);

            builder.Property(p => p.Method)
                .IsRequired()
                .HasColumnName("Method")
                .HasConversion<string>() // Para converter e salvar como texto
                .HasMaxLength(16);

            // Relacionamento com order no map de Order

        }
    }
}
