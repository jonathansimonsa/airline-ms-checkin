using CheckIn.Domain.Event;
using CheckIn.Infraestructure.EF.Config.Adm;
using CheckIn.Infraestructure.EF.Config.CheckIn;
using CheckIn.Infraestructure.EF.Config.Ticket;
using CheckIn.Infraestructure.EF.Config.Vuelo;
using CheckIn.Infraestructure.EF.ReadModel.Adm;
using CheckIn.Infraestructure.EF.ReadModel.CheckIn;
using CheckIn.Infraestructure.EF.ReadModel.Ticket;
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
		public virtual DbSet<AdministrativoReadModel> Adm_Db { get; set; }
		public virtual DbSet<VueloReadModel> Vuelo_Db { get; set; }
		public virtual DbSet<TicketReadModel> Ticket_Db { get; set; }
		public virtual DbSet<CheckInReadModel> CheckIn_Db { get; set; }
		public virtual DbSet<EquipajeReadModel> Equipaje_Db { get; set; }

		public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) {
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			var admConfig = new AdmReadConfig();
			modelBuilder.ApplyConfiguration<AdministrativoReadModel>(admConfig);

			var vueloConfig = new VueloReadConfig();
			modelBuilder.ApplyConfiguration<VueloReadModel>(vueloConfig);

			var ticketConfig = new TicketReadConfig();
			modelBuilder.ApplyConfiguration<TicketReadModel>(ticketConfig);

			var checkInConfig = new CheckInReadConfig();
			modelBuilder.ApplyConfiguration<CheckInReadModel>(checkInConfig);

			var equipajeConfig = new EquipajeReadConfig();
			modelBuilder.ApplyConfiguration<EquipajeReadModel>(equipajeConfig);

			modelBuilder.Ignore<DomainEvent>();
			modelBuilder.Ignore<CheckInCreado>();
		}

	}
}
