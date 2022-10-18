using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CheckIn.Test.ShareKernel.Core {
	public record ClassValueObject_Test : ValueObject {
		public ClassValueObject_Test() {
			try {
				CheckRule(null);
			}
			catch (Exception) { }
			try {
				CheckRule(new StringNotNullOrEmptyRule(null));
			}
			catch (Exception) { }
			try {
				CheckRule(new StringNotNullOrEmptyRule("test"));
			}
			catch (Exception) { }

		}
	}
}
