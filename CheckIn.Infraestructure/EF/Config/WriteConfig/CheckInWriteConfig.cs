using CheckIn.Domain.Model;
using CheckIn.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.WriteConfig
{
    public class CheckInWriteConfig : IEntityTypeConfiguration<Domain.Model.CheckIn>
    {
        public void Configure(EntityTypeBuilder<Domain.Model.CheckIn> builder)
        {
            builder.ToTable("CheckIn");
            builder.HasKey(x => x.Id);

            var nroCheckInConverter = new ValueConverter<NumeroCheckInValue, string>(
                nroCheckInValue => nroCheckInValue.Value,
                nroCheckIn => new NumeroCheckInValue(nroCheckIn)
            );

            builder.Property(x => x.NroCheckIn)
                .HasConversion(nroCheckInConverter)
                .HasColumnName("nroCheckIn")
                .HasMaxLength(6);

            builder.Property(x => x.HoraCheckIn)
                .HasColumnType("datetime")
                .HasColumnName("horaCheckIn");

            builder.Property(x => x.EsAltaPrioridad)
                .HasColumnType("decimal")
                .HasColumnName("esAltaPrioridad")
                .HasPrecision(12, 2);

            builder.HasMany(typeof(Equipaje), "_DetalleEquipaje");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.DetalleEquipaje);
        }
    }
}
