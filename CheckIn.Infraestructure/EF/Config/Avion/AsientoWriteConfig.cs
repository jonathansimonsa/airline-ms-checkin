using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Asiento {
	public class AsientoWriteConfig : IEntityTypeConfiguration<Domain.Model.Avion.Asiento> {
		public void Configure(EntityTypeBuilder<Domain.Model.Avion.Asiento> builder) {
			builder.ToTable("Asiento");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Codigo)
				.HasMaxLength(10)
				.HasColumnName("descripcion");

			builder.Property(x => x.Fila)
				.HasColumnName("fila")
				.HasColumnType("int");

			builder.Property(x => x.Letra)
				.HasMaxLength(10)
				.HasColumnName("letra");

			builder.Property(x => x.EsPrioridad)
				.HasColumnName("esPrioridad")
				.HasColumnType("int");

		}
	}
}
