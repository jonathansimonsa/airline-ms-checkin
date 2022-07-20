using CheckIn.Domain.Model.Adm;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Repository {
	public class AdministrativoRepository : IAdministrativoRepository {
		public readonly DbSet<Administrativo> _adm;

		public AdministrativoRepository(WriteDbContext context) {
			_adm = context.Administrativo;
		}

		public async Task CreateAsync(Administrativo obj) {
			await _adm.AddAsync(obj);
		}

		public Task<Administrativo> FindByIdAsync(Guid id) {
			return _adm.SingleAsync(x => x.Id == id);
		}

		public Task<List<Administrativo>> GellAll() {
			return _adm.ToListAsync();
		}

		public Task Updateasync(Administrativo obj) {
			_adm.Update(obj);
			return Task.CompletedTask;
		}
	}
}
