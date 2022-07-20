using CheckIn.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Application.Services {
	public class CheckInService_Test {
		[Theory]
		[InlineData("QAZ", true)]
		[InlineData("123", false)]
		[InlineData("ABC", false)]
		[InlineData("789", false)]
		[InlineData(null, false)]
		public async void GenerarNroCheckIn_CheckValidData(string expected_NroCheckIn, bool isEqual) {
			var checkInService = new CheckInService();
			string nrocheckIn = await checkInService.GenerarNroCheckInAsync();
			if (isEqual) {
				Assert.Equal(expected_NroCheckIn, nrocheckIn);
			}
			else {
				Assert.NotEqual(expected_NroCheckIn, nrocheckIn);
			}
		}

	}
}
