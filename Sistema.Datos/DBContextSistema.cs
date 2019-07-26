using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping.Almacen;
using Sistema.Datos.Mapping.Wcm;
using Sistema.Entidades.Almacen;
using Sistema.Entidades.Wcm;

namespace Sistema.Datos
{
    public class DbContextSistema : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Anomalia> Anomalias { get; set; }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ArticuloMap());
            modelBuilder.ApplyConfiguration(new AreaMap());
            modelBuilder.ApplyConfiguration(new AnomaliaMap());
            modelBuilder.ApplyConfiguration(new TarjetaMap());
        }

    }
}
