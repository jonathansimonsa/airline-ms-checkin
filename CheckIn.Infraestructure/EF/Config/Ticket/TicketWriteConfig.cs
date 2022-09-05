using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Ticket {
	public class TicketWriteConfig : IEntityTypeConfiguration<Domain.Model.Ticket.Ticket> {
		public void Configure(EntityTypeBuilder<Domain.Model.Ticket.Ticket> builder) {
			builder.ToTable("Ticket");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.NroTicket)
				.HasColumnName("nroTicket")
				.HasColumnType("decimal")
				.HasPrecision(12, 2);

			builder.Property(x => x.HoraReserva)
				.HasColumnName("horaReserva")
				.HasColumnType("datetime");

		}
	}
}
