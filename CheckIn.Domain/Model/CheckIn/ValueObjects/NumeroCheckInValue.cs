using ShareKernel.Core;
using ShareKernel.Rules;

namespace CheckIn.Domain.Model.CheckIn.ValueObjects {
	public record NumeroCheckInValue : ValueObject {
		public string Value { get; }

		public NumeroCheckInValue(string value) {
			CheckRule(new StringNotNullOrEmptyRule(value));
			//TODO: validar el formato del numero
			Value = value;
		}


		public static implicit operator string(NumeroCheckInValue value) {
			return value.Value;
		}

		public static implicit operator NumeroCheckInValue(string value) {
			return new NumeroCheckInValue(value);
		}



	}
}
