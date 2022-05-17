using CheckIn.Infraestructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.ReadConfig
{
    public class CheckInReadConfig : IEntityTypeConfiguration<CheckInReadModel>
    {
        public void Configure(EntityTypeBuilder<CheckInReadModel> builder)
        {
            builder.ToTable("CheckIn");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroCheckIn)
                .HasColumnName("nroCheckIn")
                .HasMaxLength(10);

            builder.Property(x => x.HoraCheckIn)
                .HasColumnName("horaCheckIn")
                .HasColumnType("datetime");

            builder.Property(x => x.EsAltaPrioridad)
                .HasColumnName("esAltaPrioridad")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasMany(x => x.DetalleEquipaje)
                          .WithOne(x => x.CheckIn); 
        }

    }
}
