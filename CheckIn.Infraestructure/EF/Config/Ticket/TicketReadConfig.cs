using CheckIn.Infraestructure.EF.ReadModel.Ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Ticket
{
    public class TicketReadConfig : IEntityTypeConfiguration<TicketReadModel>
    {
        public void Configure(EntityTypeBuilder<TicketReadModel> builder)
        {
            builder.ToTable("Ticket");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.HoraReserva)
                .HasColumnType("datetime")
                .HasColumnName("horaReserva");

        }
    }
}
