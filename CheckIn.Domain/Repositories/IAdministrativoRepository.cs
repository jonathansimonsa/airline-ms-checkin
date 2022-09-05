using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Repositories {
	public interface IAdministrativoRepository : IRepository<Model.Adm.Administrativo, Guid> {
		Task<List<Model.Adm.Administrativo>> GetAll();

		Task Updateasync(Model.Adm.Administrativo obj);

		Task Deleteasync(Model.Adm.Administrativo obj);
	}
}
