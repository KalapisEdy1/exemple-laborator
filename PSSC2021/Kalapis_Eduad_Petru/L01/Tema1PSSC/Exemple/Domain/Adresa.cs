using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tema1PSSC.Domain
{
    public record Adresa
    {
        private static readonly Regex ValidPattern = new("^nr[0-9]{10}$");

        public string Value { get; }

        private Adresa(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidAdressException("");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
