using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1PSSC.Domain
{
    public record Pret
    {
        public decimal Value { get; }

        public Pret(decimal value)
        {
            if (value >= 0)
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductQuantity($"{value:0.##} is an invalid price value.");
            }
        }
        public override string ToString()
        {
            return $"{Value:0.##}";
        }
        public static bool TryParsePret(string PretString, out Pret pret)
        {
            bool isValid = false;
            pret = null;
            if (decimal.TryParse(PretString, out decimal pr))
            {
                if (IsValid(pr))
                {
                    isValid = true;
                    pret = new(pr);
                }
            }

            return isValid;
        }

        private static bool IsValid(decimal pr) => pr > 0 && pr <= 9999;
    }
}

