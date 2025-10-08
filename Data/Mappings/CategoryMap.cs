using FoodTime.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTime.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            {

                // Tabela do banco
                builder.ToTable("Category");

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

                // Relacionamentos

                //Relacionamento com product em ProductMap

            }
        }
    }
}
