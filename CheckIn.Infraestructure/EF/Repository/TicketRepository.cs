using CheckIn.Domain.Model.Ticket;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Repository
{
   public class TicketRepository : ITicketRepository
    {
        public readonly DbSet<Domain.Model.Ticket.Ticket> _ticket;

        public TicketRepository(WriteDbContext context)
        {
            _ticket = context.Ticket;
        }

        public async Task CreateAsync(Ticket obj)
        {
            await _ticket.AddAsync(obj);
        }

        public Task<Ticket> FindByIdAsync(Guid id)
        {
            return _ticket.SingleAsync(x => x.Id == id);
        }

        public Task<List<Ticket>> GellAll()
        {
            return _ticket.ToListAsync();
        }

        public Task Updateasync(Ticket obj)
        {
            _ticket.Update(obj);
            return Task.CompletedTask;
        }
    }
}
