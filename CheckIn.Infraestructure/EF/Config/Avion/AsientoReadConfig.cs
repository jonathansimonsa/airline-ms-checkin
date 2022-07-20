using CheckIn.Infraestructure.EF.ReadModel.Avion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Avion {
	public class AsientoReadConfig : IEntityTypeConfiguration<AsientoReadModel> {
		public void Configure(EntityTypeBuilder<AsientoReadModel> builder) {

			builder.ToTable("Asiento");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Codigo)
				.HasColumnName("codigo")
				.HasMaxLength(10);

			builder.Property(x => x.Fila)
				.HasColumnName("fila")
				.HasColumnType("int");

			builder.Property(x => x.Letra)
				.HasColumnName("letra")
				.HasMaxLength(10);

			builder.Property(x => x.EsPrioridad)
				.HasColumnName("esPrioridad")
				.HasColumnType("int");
		}
	}
}
