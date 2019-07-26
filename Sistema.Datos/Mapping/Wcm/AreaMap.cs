using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Wcm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Wcm
{
    class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("tb_area")
               .HasKey(c => c.id);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.descripcion)
                .HasMaxLength(256);
        }
    }
}
