using System.Threading.Tasks;

namespace CheckIn.Domain.Repositories {
	public interface IUnitOfWork {
		Task Commit();
	}
}
