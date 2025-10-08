using FoodTime.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTime.Data.Mappings
{
    public class RestaurantMap : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {

            // Tabela do banco
            builder.ToTable("Restaurant");

            // Chave primaria
            builder.HasKey(r => r.Id);

            //Identity
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(r => r.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(32);

            builder.Property(r=> r.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasConversion<string>() // Para converter e salvar como texto
                .HasMaxLength(16);

        }
    }
}
