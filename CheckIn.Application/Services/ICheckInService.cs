using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.Services {
	public interface ICheckInService {
		Task<string> GenerarNroCheckInAsync();
	}
}
