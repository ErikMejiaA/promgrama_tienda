using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Producto");

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.FechaCreacion)
        .HasColumnType("datetime");

        builder.Property(p => p.Precio)
        .HasColumnType("decimal(10,8)");

        //se declaran las llaves foraneas a las tablas estas se deven hacer desde la clase o entidad hija en este claso producto

        builder.HasOne(p => p.Marca)
        .WithMany(p => p.Productos)
        .HasForeignKey(p => p.MarcaId);

        builder.HasOne(p => p.Categoria)
        .WithMany(p => p.Productos)
        .HasForeignKey(p => p.CategoriaId);

    }

}
