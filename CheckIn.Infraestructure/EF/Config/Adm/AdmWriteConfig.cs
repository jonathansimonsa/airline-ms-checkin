using CheckIn.Domain.Model.Adm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Adm
{
    public class AdmWriteConfig : IEntityTypeConfiguration<Domain.Model.Adm.Administrativo>
    {
        public void Configure(EntityTypeBuilder<Administrativo> builder)
        {
            builder.ToTable("Administrativo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ci)
                .HasMaxLength(50)
                .HasColumnName("ci");

            builder.Property(x => x.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");

            builder.Property(x => x.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");

            builder.Property(x => x.Cargo)
                .HasMaxLength(100)
                .HasColumnName("cargo");
        }
    }
}
