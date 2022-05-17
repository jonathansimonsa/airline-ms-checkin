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
    public class EquipajeWriteConfig : IEntityTypeConfiguration<Equipaje>
    {
        public void Configure(EntityTypeBuilder<Equipaje> builder)
        {
            builder.ToTable("Equipaje");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");

            var pesoConverter = new ValueConverter<PesoValue, decimal>(
                pesoValue => pesoValue.ValorKg,
                peso => new PesoValue(peso)
            );

            builder.Property(x => x.Peso)
                .HasConversion(pesoConverter)
                .HasColumnName("peso")
                .HasPrecision(12, 2);

            builder.Property(x => x.EsFragil)
                .HasColumnType("decimal")
                .HasColumnName("esFragil")
                .HasPrecision(12, 2);
        }
    }
}
