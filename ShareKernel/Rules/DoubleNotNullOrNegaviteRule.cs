using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.Rules {
	public class DoubleNotNullOrNegaviteRule : IBussinessRule {
		private readonly double _value;

		public DoubleNotNullOrNegaviteRule(double value) {
			_value = value;
		}

		public string Message => "Double cannot be null or negative";

		public bool IsValid() {
			if (_value < 0)
				return false;

			return true;
		}
	}
}
