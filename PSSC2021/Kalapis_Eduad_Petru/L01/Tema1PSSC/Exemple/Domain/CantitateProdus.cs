using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1PSSC.Domain
{
    public record CantitateProdus
    {
        public decimal Value { get; }

        public CantitateProdus(int value)
        {
            if (value >=0)
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductQuantity($"{value:0.##} is an invalid product quantity value.");
            }
        }
        public override string ToString()
        {
            return $"{Value:0.##}";
        }
    }
}
