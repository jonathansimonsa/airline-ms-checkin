using CheckIn.Domain.Event;
using CheckIn.Domain.Model.Adm;
using CheckIn.Domain.Model.Avion;
using CheckIn.Domain.Model.CheckIn;
using CheckIn.Domain.Model.Ticket;
using CheckIn.Infraestructure.EF.Config.CheckIn;
using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {

        public virtual DbSet<Domain.Model.CheckIn.CheckIn> CheckIn { get; set; }
        public virtual DbSet<Equipaje> Equipaje { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Asiento> Asiento { get; set; }
        public virtual DbSet<Administrativo> Administrativo { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var checkInConfig = new CheckInWriteConfig();
            modelBuilder.ApplyConfiguration<Domain.Model.CheckIn.CheckIn>(checkInConfig);

            var equipajeCnonfig = new EquipajeWriteConfig();
            modelBuilder.ApplyConfiguration<Equipaje>(equipajeCnonfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<CheckInCreado>();

        }

    }
}
