using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Wcm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Wcm
{
    class TarjetaMap : IEntityTypeConfiguration<Tarjeta>
    {
       

        public void Configure(EntityTypeBuilder<Tarjeta> builder)
        {
            builder.ToTable("tb_tarjeta")
              .HasKey(c => c.idtarjeta);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.descripcion)
                .HasMaxLength(256);

        }
    }
}
