using CheckIn.Infraestructure.EF.ReadModel.CheckIn;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.CheckIn {
	public class EquipajeReadConfig : IEntityTypeConfiguration<EquipajeReadModel> {
		public void Configure(EntityTypeBuilder<EquipajeReadModel> builder) {
			builder.ToTable("Equipaje");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Descripcion)
				.HasColumnName("descripcion")
				.HasMaxLength(200);

			builder.Property(x => x.Peso)
				.HasColumnName("peso")
				.HasColumnType("decimal")
				.HasPrecision(12, 2);

			builder.Property(x => x.EsFragil)
				.HasColumnName("esFragil")
				.HasColumnType("int");
		}
	}
}
