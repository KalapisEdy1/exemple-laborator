using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1PSSC.Domain
{
    [AsChoice]
    public static partial class Carucior
    {
        public interface ICaruciorProduse { }

        public record CaruciorProduseGol(IReadOnlyCollection<CaruciorGol> CosCumparaturi) : ICaruciorProduse;

        public record CaruciorProduseNevalidat(IReadOnlyCollection<CaruciorGol> CosCumparaturi, string reason) : ICaruciorProduse;

        public record CaruciorProduseValidat(IReadOnlyCollection<CaruciorValidat> CosCumparaturi) : ICaruciorProduse;

        public record CaruciorProdusePlatit(IReadOnlyCollection<CaruciorValidat> CosCumparaturi, DateTime PublishedDate) : ICaruciorProduse;
    }

}
