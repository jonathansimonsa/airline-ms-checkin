using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Repositories
{
    public interface ICheckInRepository : IRepository<Model.CheckIn, Guid>
    {
        Task Updateasync(Model.CheckIn obj);

    }
}
