using CheckIn.Domain.Model.CheckIn.ValueObjects;
using CheckIn.Domain.Model.CheckIn;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Vuelo {
	public class VueloWriteConfig : IEntityTypeConfiguration<Domain.Model.Vuelo.Vuelo> {
		public void Configure(EntityTypeBuilder<Domain.Model.Vuelo.Vuelo> builder) {
			builder.ToTable("Vuelo");
			builder.HasKey(x => x.Id);

			var nroCheckInConverter = new ValueConverter<NumeroCheckInValue, string>(
				nroCheckInValue => nroCheckInValue.Value,
				nroCheckIn => new NumeroCheckInValue(nroCheckIn)
			);

			builder.Property(x => x.NroVuelo)
				.HasColumnName("nroVuelo")
				.HasColumnType("decimal")
				.HasPrecision(12, 2);

			builder.Property(x => x.Origen)
				.HasColumnName("origen")
				.HasMaxLength(100);

			builder.Property(x => x.Destino)
				.HasColumnName("destino")
				.HasMaxLength(100);

			builder.Property(x => x.Partida)
				.HasColumnName("partida")
				.HasColumnType("datetime");

			builder.Property(x => x.Llegada)
				.HasColumnName("llegada")
				.HasColumnType("datetime");

		}
	}
}
