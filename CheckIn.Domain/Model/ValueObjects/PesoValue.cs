using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model.ValueObjects
{
    public record PesoValue : ValueObject
    {
        public decimal ValorKg { get; }

        public PesoValue(decimal valorKg)
        {
            if (valorKg < 0)
            {
                throw new BussinessRuleValidationException("Price value cannot be negative");
            }
            ValorKg = valorKg;
        }

        public static implicit operator decimal(PesoValue valorKg)
        {
            return valorKg.ValorKg;
        }

        public static implicit operator PesoValue(decimal valorKg)
        {
            return new PesoValue(valorKg);
        }
    }
}
