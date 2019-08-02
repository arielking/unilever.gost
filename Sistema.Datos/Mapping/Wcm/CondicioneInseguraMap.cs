using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Wcm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Wcm
{
    class CondicioneInseguraMap : IEntityTypeConfiguration<CondicionInsegura>
    {
        public void Configure(EntityTypeBuilder<CondicionInsegura> builder)
        {
            builder.ToTable("tb_cond_inseg")
                .HasKey(c => c.idcondinsegura);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.descripcion)
                .HasMaxLength(256);
        }
    }
}
