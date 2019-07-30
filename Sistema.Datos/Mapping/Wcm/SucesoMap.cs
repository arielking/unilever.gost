using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Wcm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Wcm
{
    class SucesoMap : IEntityTypeConfiguration<Suceso>
    {
        public void Configure(EntityTypeBuilder<Suceso> builder)
        {
            builder.ToTable("tb_suceso_relacionado")
              .HasKey(c => c.id);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.descripcion)
                .HasMaxLength(256);
        }
    }
}
