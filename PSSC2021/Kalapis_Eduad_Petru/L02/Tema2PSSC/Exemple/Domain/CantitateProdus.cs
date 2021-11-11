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

        public CantitateProdus(decimal value)
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
        public static bool TryParseCantitateProdus(string CantitateProdusString, out CantitateProdus cantitateprodus)
        {
            bool isValid = false;
            cantitateprodus = null;
            if (decimal.TryParse(CantitateProdusString, out decimal cantitate))
            {
                if (IsValid(cantitate))
                {
                    isValid = true;
                    cantitateprodus = new(cantitate);
                }
            }

            return isValid;
        }

        private static bool IsValid(decimal cantitate) => cantitate > 0 && cantitate <= 1000;
    }
}
