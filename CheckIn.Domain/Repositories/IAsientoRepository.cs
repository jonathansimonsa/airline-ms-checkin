using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Repositories {
	public interface IAsientoRepository : IRepository<Model.Avion.Asiento, Guid> {
		Task<List<Model.Avion.Asiento>> GellAll();

		Task Updateasync(Model.Avion.Asiento obj);
	}
}
