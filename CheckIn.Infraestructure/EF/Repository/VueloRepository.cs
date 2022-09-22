using CheckIn.Domain.Model.Vuelo;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Repository {
	public class VueloRepository : IVueloRepository {
		public readonly DbSet<Domain.Model.Vuelo.Vuelo> _vuelo;

		public VueloRepository(WriteDbContext context) {
			_vuelo = context.Vuelo;
		}

		public Task<List<Domain.Model.Vuelo.Vuelo>> GetAll() {
			return _vuelo.ToListAsync();
		}

		public Task Updateasync(Domain.Model.Vuelo.Vuelo obj) {
			_vuelo.Update(obj);
			return Task.CompletedTask;
		}

		public Task Deleteasync(Domain.Model.Vuelo.Vuelo obj) {
			_vuelo.Remove(obj);
			return Task.CompletedTask;
		}

		public Task<Domain.Model.Vuelo.Vuelo> FindByIdAsync(Guid id) {
			return _vuelo.SingleAsync(x => x.Id == id);
		}

		public async Task CreateAsync(Domain.Model.Vuelo.Vuelo obj) {
			await _vuelo.AddAsync(obj);
		}
	}
}
