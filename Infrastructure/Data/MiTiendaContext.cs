using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MiTiendaContext : DbContext
{
    public MiTiendaContext(DbContextOptions<MiTiendaContext> options) : base(options)
    {

    }

    public DbSet<Producto> ? Productos { get; set;}
    public DbSet<Marca> ? Marcas { get; set; }
    public DbSet<Categoria> ? Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
