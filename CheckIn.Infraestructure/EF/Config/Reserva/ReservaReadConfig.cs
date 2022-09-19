using CheckIn.Infraestructure.EF.ReadModel.Reserva;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Reserva {
	public class ReservaReadConfig : IEntityTypeConfiguration<ReservaReadModel> {
		public void Configure(EntityTypeBuilder<ReservaReadModel> builder) {
			builder.ToTable("Reserva");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.NroReserva)
				.HasColumnName("nroReserva")
				.HasColumnType("int");

			builder.Property(x => x.Hora)
				.HasColumnName("hora")
				.HasColumnType("datetime");

		}
	}
}
