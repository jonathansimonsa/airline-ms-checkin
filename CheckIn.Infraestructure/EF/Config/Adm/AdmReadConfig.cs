using CheckIn.Infraestructure.EF.ReadModel.Adm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Config.Adm {
	public class AdmReadConfig : IEntityTypeConfiguration<AdministrativoReadModel> {
		public void Configure(EntityTypeBuilder<AdministrativoReadModel> builder) {
			builder.ToTable("Administrativo");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Ci)
				.HasColumnName("ci")
				.HasMaxLength(50);

			builder.Property(x => x.Nombres)
				.HasColumnName("nombres")
				.HasMaxLength(100);

			builder.Property(x => x.Apellidos)
				.HasColumnName("apellidos")
				.HasMaxLength(100);

			builder.Property(x => x.Cargo)
				.HasColumnName("cargo")
				.HasMaxLength(100);
		}
	}
}
