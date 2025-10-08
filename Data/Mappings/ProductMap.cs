using FoodTime.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTime.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            // Tabela do banco
            builder.ToTable("Product");

            // Chave primaria
            builder.HasKey(p => p.Id);

            //Identity
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(32);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(128);

            builder.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnName("Price")
                    .HasColumnType("decimal(18,2)")
                    .HasDefaultValue(0m);

            // Relacionamentos

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Product_Category")
                .OnDelete(DeleteBehavior.Restrict);

                
        }
    }
}
