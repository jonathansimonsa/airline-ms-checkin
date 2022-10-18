using CheckIn.Domain.Model.Reserva;
using CheckIn.Domain.Model.Vuelo;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Repository {
	[ExcludeFromCodeCoverage]
	public class CheckInRepository : ICheckInRepository {
		public readonly DbSet<Domain.Model.CheckIn.CheckIn> _checkIn;

		public CheckInRepository(WriteDbContext context) {
			_checkIn = context.CheckIn;
		}

		public async Task CreateAsync(Domain.Model.CheckIn.CheckIn obj) {
			await _checkIn.AddAsync(obj);
		}

		public Task<Domain.Model.CheckIn.CheckIn> FindByIdAsync(Guid id) {
			return _checkIn.Include("_DetalleEquipaje")
				.SingleAsync(x => x.Id == id);
		}

		public Task<List<Domain.Model.CheckIn.CheckIn>> GetAll() {
			return _checkIn.Include("_DetalleEquipaje").ToListAsync();
		}

		public Task Updateasync(Domain.Model.CheckIn.CheckIn obj) {
			_checkIn.Update(obj);
			return Task.CompletedTask;
		}
		public Task Deleteasync(Guid id) {
			var obj = FindByIdAsync(id).Result;
			_checkIn.Remove(obj);
			return Task.CompletedTask;
		}

		public Task<List<Domain.Model.CheckIn.CheckIn>> GetByVueloAndPrioridad(Guid vueloId, int esAltaPrioridad) {
			return _checkIn.Where(p => p.VueloId == vueloId && p.EsAltaPrioridad == esAltaPrioridad).ToListAsync();
		}

		public Task<List<Domain.Model.CheckIn.CheckIn>> GetByReservaId(Guid reservaId) {
			return _checkIn.Where(p => p.ReservaId == reservaId).ToListAsync();
		}
	}
}
