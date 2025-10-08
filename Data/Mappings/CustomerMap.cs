using FoodTime.Models;
using FoodTime.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTime.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Tabela do banco
            builder.ToTable("Customer");

            // Chave primaria
            builder.HasKey(c => c.Id);

            //Identity
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(64);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasConversion(
                    email => email.Address,
                    address => Email.Create(address))
                .HasMaxLength(256);

            builder.Property(c => c.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(256);

            //Indices
            builder.HasIndex(c => c.Email, "IX_CustomerEmail")
                .IsUnique();

            //Relacionamentos

            //Relacionamento com order no OrderMap
        }
    }
}
