using CheckIn.Infraestructure.EF.ReadModel.CheckIn;
using CheckIn.Infraestructure.EF.ReadModel.Vuelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Vuelo {
	[ExcludeFromCodeCoverage]
	public class VueloReadConfig : IEntityTypeConfiguration<VueloReadModel> {
		public void Configure(EntityTypeBuilder<VueloReadModel> builder) {
			builder.ToTable("Vuelo");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.NroVuelo)
				.HasColumnName("nroVuelo")
				.HasColumnType("int");

			builder.Property(x => x.Origen)
				.HasColumnName("origen")
				.HasMaxLength(100);

			builder.Property(x => x.Destino)
				.HasColumnName("destino")
				.HasMaxLength(100);
		}
	}
}
