using CheckIn.Application.UseCases.CheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.UseCases {
	public class GetCheckInByIdQuery_Test {

		[Fact]
		public void GetCheckInByIdQuery_DataValid() {
			var id = Guid.NewGuid();
			var command = new GetCheckInByIdQuery(id);

			Assert.Equal(id, command.Id);
		}

		[Fact]
		public void Constructor_isPridate() {
			var command = (GetCheckInByIdQuery)Activator.CreateInstance(typeof(GetCheckInByIdQuery), true);

			Assert.Equal(Guid.Empty, command.Id);
		}
	}
}
