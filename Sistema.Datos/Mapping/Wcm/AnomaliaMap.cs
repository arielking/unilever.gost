using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Wcm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Wcm
{
    class AnomaliaMap : IEntityTypeConfiguration<Anomalia>
    {

        // clase de contructures
        public void Configure(EntityTypeBuilder<Anomalia> builder)
        {
            builder.ToTable("tb_anomalia")
               .HasKey(c => c.idanomalia);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.descripcion)
                .HasMaxLength(256);
        }
    }
}
