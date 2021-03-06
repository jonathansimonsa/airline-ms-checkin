using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Repositories {
	public interface ITicketRepository : IRepository<Model.Ticket.Ticket, Guid> {
		Task<List<Model.Ticket.Ticket>> GellAll();

		Task Updateasync(Model.Ticket.Ticket obj);
	}
}
