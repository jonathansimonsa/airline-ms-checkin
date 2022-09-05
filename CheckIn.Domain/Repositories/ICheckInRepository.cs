using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Repositories {
	public interface ICheckInRepository : IRepository<Model.CheckIn.CheckIn, Guid> {
		Task<List<Model.CheckIn.CheckIn>> GetAll();

		Task Updateasync(Model.CheckIn.CheckIn obj);

		Task Deleteasync(Model.CheckIn.CheckIn obj);

		Task<List<Model.CheckIn.CheckIn>> GetByVueloAndPrioridad(Guid vueloId, int esAltaPrioridad);

		Task<List<Model.CheckIn.CheckIn>> GetByTicketId(Guid ticketId);

	}
}
