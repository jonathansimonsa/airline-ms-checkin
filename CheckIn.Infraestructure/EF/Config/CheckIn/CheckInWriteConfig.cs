using CheckIn.Domain.Model.CheckIn;
using CheckIn.Domain.Model.CheckIn.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.CheckIn {
	[ExcludeFromCodeCoverage]
	public class CheckInWriteConfig : IEntityTypeConfiguration<Domain.Model.CheckIn.CheckIn> {
		public void Configure(EntityTypeBuilder<Domain.Model.CheckIn.CheckIn> builder) {
			builder.ToTable("CheckIn");
			builder.HasKey(x => x.Id);

			var nroCheckInConverter = new ValueConverter<NumeroCheckInValue, string>(
				nroCheckInValue => nroCheckInValue.Value,
				nroCheckIn => new NumeroCheckInValue(nroCheckIn)
			);

			builder.Property(x => x.NroCheckIn)
				.HasConversion(nroCheckInConverter)
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

			builder.HasMany(typeof(Equipaje), "_DetalleEquipaje");

			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
			builder.Ignore(x => x.DetalleEquipaje);
		}
	}
}
