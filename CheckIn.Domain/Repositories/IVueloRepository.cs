using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Repositories {
	public interface IVueloRepository : IRepository<Model.Vuelo.Vuelo, Guid> {
		Task<List<Model.Vuelo.Vuelo>> GetAll();

		Task Updateasync(Model.Vuelo.Vuelo obj);

		Task Deleteasync(Model.Vuelo.Vuelo obj);

	}
}
