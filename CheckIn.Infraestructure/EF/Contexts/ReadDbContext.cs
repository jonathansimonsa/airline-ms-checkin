using CheckIn.Domain.Event;
using CheckIn.Infraestructure.EF.Config.ReadConfig;
using CheckIn.Infraestructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Contexts
{
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<CheckInReadModel> CheckIn_Db { get; set; }
        public virtual DbSet<EquipajeReadModel> Equipaje_Db { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options):base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var checkInConfig = new CheckInReadConfig();
            modelBuilder.ApplyConfiguration<CheckInReadModel>(checkInConfig);

            var equipajeCnonfig = new EquipajeReadConfig();
            modelBuilder.ApplyConfiguration<EquipajeReadModel>(equipajeCnonfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<CheckInCreado>();
        }

    }
}
