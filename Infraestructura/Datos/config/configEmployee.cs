using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.config
{
    public class configEmployee :IEntityTypeConfiguration<employees>
    {
        public void Configure(EntityTypeBuilder<employees> builder)
        {
            builder.Property(l => l.Id).IsRequired();
            builder.Property(l => l.FullName).IsRequired().HasMaxLength(100);
            builder.Property(l => l.correo).IsRequired();
            builder.Property(l => l.birdDate).IsRequired();
            builder.HasOne(c => c.job).WithMany()
                .HasForeignKey(l => l.Idjob);

            builder.HasOne(c => c.user).WithMany()
                .HasForeignKey(l => l.createAt);
        }
    }
}