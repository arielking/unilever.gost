using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Wcm;

namespace Sistema.Datos.Mapping.Wcm
{
    class FallaMap : IEntityTypeConfiguration<Falla>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Falla> builder)
        {
            builder.ToTable("tb_tipo_falla")
                .HasKey(c => c.idfalla);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.descripcion)
                .HasMaxLength(256);
        }
    }
}
