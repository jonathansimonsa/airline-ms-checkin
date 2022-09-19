using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Repositories {
	public interface IReservaRepository : IRepository<Model.Reserva.Reserva, Guid> {
		Task<List<Model.Reserva.Reserva>> GetAll();

		Task Updateasync(Model.Reserva.Reserva obj);

		Task Deleteasync(Model.Reserva.Reserva obj);

	}
}
