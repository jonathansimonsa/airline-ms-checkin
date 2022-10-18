using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Reserva {
	[ExcludeFromCodeCoverage]
	public class ReservaWriteConfig : IEntityTypeConfiguration<Domain.Model.Reserva.Reserva> {
		public void Configure(EntityTypeBuilder<Domain.Model.Reserva.Reserva> builder) {
			builder.ToTable("Reserva");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.NroReserva)
				.HasColumnName("nroReserva")
				.HasColumnType("decimal")
				.HasPrecision(12, 2);

			builder.Property(x => x.Hora)
				.HasColumnName("hora")
				.HasColumnType("datetime");

		}
	}
}
