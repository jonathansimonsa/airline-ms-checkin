using CheckIn.Infraestructure.EF.Config.Adm;
using CheckIn.Infraestructure.EF.ReadModel.Adm;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIn.Test.Infraestructure.Config {
	public class AdmReadConfig_Test {
		[Fact]
		public void Check() {
			var config = new AdmReadConfig();
			Assert.NotNull(config);
		}
	}
}
