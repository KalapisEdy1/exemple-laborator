using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1PSSC.Domain
{
    [AsChoice]
    public static partial class CaruciorPlatitEvent
    {
        public interface ICaruciorPlatitEvent { }

        public record CaruciorPlatitSuccededEvent : ICaruciorPlatitEvent
        {
            public string Csv { get; }
            public decimal PretProdus { get; }
            public DateTime PublishedDate { get; }

            internal CaruciorPlatitSuccededEvent(string csv, decimal pretprodus,DateTime publishedDate)
            {
                Csv = csv;
                PretProdus = pretprodus;
                PublishedDate = publishedDate;
            }
        }

        public record CaruciorPlatitFaildEvent : ICaruciorPlatitEvent
        {
            public string Reason { get; }

            internal CaruciorPlatitFaildEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}
