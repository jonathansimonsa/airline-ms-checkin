using CheckIn.Domain.Model.CheckIn;
using CheckIn.Domain.Model.Reserva;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Repository {
	public class ReservaRepository : IReservaRepository {
		public readonly DbSet<Reserva> _reserva;

		public ReservaRepository(WriteDbContext context) {
			_reserva = context.Reserva;
		}

		public async Task CreateAsync(Reserva obj) {
			await _reserva.AddAsync(obj);
		}

		public Task<Reserva> FindByIdAsync(Guid id) {
			return _reserva.SingleAsync(x => x.Id == id);
		}

		public Task<List<Reserva>> GetAll() {
			return _reserva.ToListAsync();
		}

		public Task Updateasync(Reserva obj) {
			_reserva.Update(obj);
			return Task.CompletedTask;
		}

		public Task Deleteasync(Reserva obj) {
			_reserva.Remove(obj);
			return Task.CompletedTask;
		}
	}
}
