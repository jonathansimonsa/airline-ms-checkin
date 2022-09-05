using CheckIn.Domain.Model.Vuelo;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Repository {
	public class VueloRepository : IVueloRepository {
		public readonly DbSet<Vuelo> _vuelo;

		public VueloRepository(WriteDbContext context) {
			_vuelo = context.Vuelo;
		}

		public async Task CreateAsync(Vuelo obj) {
			await _vuelo.AddAsync(obj);
		}

		public Task<Vuelo> FindByIdAsync(Guid id) {
			return _vuelo.SingleAsync(x => x.Id == id);
		}

		public Task<List<Vuelo>> GetAll() {
			return _vuelo.ToListAsync();
		}

		public Task Updateasync(Vuelo obj) {
			_vuelo.Update(obj);
			return Task.CompletedTask;
		}
		public Task Deleteasync(Vuelo obj) {
			_vuelo.Remove(obj);
			return Task.CompletedTask;
		}

	}
}
