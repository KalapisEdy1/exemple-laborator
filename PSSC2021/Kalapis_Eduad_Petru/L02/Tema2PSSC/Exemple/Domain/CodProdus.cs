using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tema1PSSC.Domain
{
    public record CodProdus
    {
        private static readonly Regex ValidPattern = new("^LM[0-9]{5}$");

        public string Value { get; }

        private CodProdus(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductCodeException("");
            }
        }

        public override string ToString()
        {
            return Value;
        }
        public static bool TryParseCodProdus(string CodProdusString, out CodProdus codprodus)
        {
            bool isValid = false;
            codprodus = null;

            if (IsValid(CodProdusString))
            {
                isValid = true;
                codprodus = new(CodProdusString);
            }

            return isValid;
        }

        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);
    }
}
