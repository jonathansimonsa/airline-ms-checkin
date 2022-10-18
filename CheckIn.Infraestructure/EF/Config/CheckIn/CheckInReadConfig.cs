using CheckIn.Infraestructure.EF.ReadModel.CheckIn;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.CheckIn {
	[ExcludeFromCodeCoverage]
	public class CheckInReadConfig : IEntityTypeConfiguration<CheckInReadModel> {
		public void Configure(EntityTypeBuilder<CheckInReadModel> builder) {
			builder.ToTable("CheckIn");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.NroCheckIn)
				.HasColumnName("nroCheckIn")
				.HasMaxLength(10);

			builder.Property(x => x.Hora)
				.HasColumnName("hora")
				.HasColumnType("datetime");

			builder.Property(x => x.EsAltaPrioridad)
				.HasColumnName("esAltaPrioridad")
				.HasColumnType("int");

			builder.Property(x => x.LetraAsiento)
				.HasColumnName("letraAsiento")
				.HasMaxLength(10);

			builder.Property(x => x.NroAsiento)
				.HasColumnName("nroAsiento")
				.HasColumnType("int");

			builder.HasMany(x => x.DetalleEquipaje)
						  .WithOne(x => x.CheckIn);
		}

	}
}
