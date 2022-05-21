using CheckIn.Domain.Model.Avion;
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
    public class AsientoRepository : IAsientoRepository
    {
        public readonly DbSet<Domain.Model.Avion.Asiento> _asiento;

        public AsientoRepository(WriteDbContext context)
        {
            _asiento = context.Asiento;
        }

        public async Task CreateAsync(Asiento obj)
        {
            await _asiento.AddAsync(obj);
        }

        public Task<Asiento> FindByIdAsync(Guid id)
        {
            return _asiento.SingleAsync(x => x.Id == id);
        }

        public Task<List<Asiento>> GellAll()
        {
            return _asiento.ToListAsync();
        }

        public Task Updateasync(Asiento obj)
        {
            _asiento.Update(obj);
            return Task.CompletedTask;
        }
    }
}
