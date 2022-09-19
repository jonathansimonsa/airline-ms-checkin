using CheckIn.Domain.Event;
using CheckIn.Infraestructure.EF.Config.CheckIn;
using CheckIn.Infraestructure.EF.Config.Reserva;
using CheckIn.Infraestructure.EF.Config.Vuelo;
using CheckIn.Infraestructure.EF.ReadModel.CheckIn;
using CheckIn.Infraestructure.EF.ReadModel.Reserva;
using CheckIn.Infraestructure.EF.ReadModel.Vuelo;
using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Contexts {
	public class ReadDbContext : DbContext {
		public virtual DbSet<VueloReadModel> Vuelo_Db { get; set; }
		public virtual DbSet<ReservaReadModel> Reserva_Db { get; set; }
		public virtual DbSet<CheckInReadModel> CheckIn_Db { get; set; }
		public virtual DbSet<EquipajeReadModel> Equipaje_Db { get; set; }

		public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) {
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			var vueloConfig = new VueloReadConfig();
			modelBuilder.ApplyConfiguration<VueloReadModel>(vueloConfig);

			var reservaConfig = new ReservaReadConfig();
			modelBuilder.ApplyConfiguration<ReservaReadModel>(reservaConfig);

			var checkInConfig = new CheckInReadConfig();
			modelBuilder.ApplyConfiguration<CheckInReadModel>(checkInConfig);

			var equipajeConfig = new EquipajeReadConfig();
			modelBuilder.ApplyConfiguration<EquipajeReadModel>(equipajeConfig);

			modelBuilder.Ignore<DomainEvent>();
			modelBuilder.Ignore<CheckInCreado>();
		}

	}
}
