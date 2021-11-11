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

        public record CaruciorProduseGol : ICaruciorProduse
        {
            public CaruciorProduseGol(IReadOnlyCollection<CaruciorNevalidat> caruciorpr, string reason)
            {
                Caruciorprod = caruciorpr;
                Reason = reason;
            }
            public IReadOnlyCollection<CaruciorNevalidat> Caruciorprod { get; }
            public string Reason { get; }
        }

        public record CaruciorProduseNevalidat : ICaruciorProduse
        {
            internal CaruciorProduseNevalidat(IReadOnlyCollection<CaruciorNevalidat> caruciorpr)
            {
                Caruciorprod = caruciorpr;
            }
            public IReadOnlyCollection<CaruciorNevalidat> Caruciorprod { get; }
        }


        public record CaruciorProduseValidat : ICaruciorProduse
        {
            internal CaruciorProduseValidat(IReadOnlyCollection<CaruciorValidat> caruciorpr, decimal pretProduse)
            {
                CaruciorProd = caruciorpr;
                PretProduse = pretProduse;
            }
            public IReadOnlyCollection<CaruciorValidat> CaruciorProd { get; }
            public decimal PretProduse { get; }
        }

        public record CaruciorProdusePlatit : ICaruciorProduse
        {
            internal CaruciorProdusePlatit(IReadOnlyCollection<CaruciorValidat> caruciorprod, string csv, DateTime publishedDate, decimal pretproduse)
            {
                CaruciorProduse = caruciorprod;
                PublishedDate = publishedDate;
                Csv = csv;
                PretProduse = pretproduse;
            }
            public IReadOnlyCollection<CaruciorValidat> CaruciorProduse { get; }
            public DateTime PublishedDate { get; }
            public string Csv { get; }
            public decimal PretProduse { get; }
        }
    }

}
