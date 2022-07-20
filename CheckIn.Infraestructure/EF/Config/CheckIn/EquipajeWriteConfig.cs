using CheckIn.Domain.Model.CheckIn;
using CheckIn.Domain.Model.CheckIn.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.CheckIn {
	public class EquipajeWriteConfig : IEntityTypeConfiguration<Equipaje> {
		public void Configure(EntityTypeBuilder<Equipaje> builder) {
			builder.ToTable("Equipaje");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Descripcion)
				.HasMaxLength(500)
				.HasColumnName("descripcion");

			var pesoConverter = new ValueConverter<PesoValue, decimal>(
				pesoValue => pesoValue.ValorKg,
				peso => new PesoValue(peso)
			);

			builder.Property(x => x.Peso)
				.HasConversion(pesoConverter)
				.HasColumnName("peso")
				.HasPrecision(12, 2);

			builder.Property(x => x.EsFragil)
				.HasColumnType("int")
				.HasColumnName("esFragil");

			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
		}
	}
}
