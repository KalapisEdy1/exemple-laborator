using System;
using Tema1PSSC.Domain;
using static Tema1PSSC.Domain.Carucior;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tema1PSSC.Domain.CaruciorPlatitEvent;

namespace Tema1PSSC
{
    class CaruciorOperations
    {
        public static ICaruciorProduse CaruciorProduseValid(Func<CodProdus, bool> checkProdusExists, CaruciorProduseNevalidat Caruciornevalidat)
        {
            List<CaruciorValidat> carucioareValidate = new();
            bool isValidList = true;
            decimal pretTotal=0;
            string invalidReson = string.Empty;
            foreach (var caruciorNevalidat in Caruciornevalidat.Caruciorprod)
            {
                if (!CantitateProdus.TryParseCantitateProdus(caruciorNevalidat.Cantitate, out CantitateProdus cantitate))
                {
                    invalidReson = $"Cantitata Produs Invalida ({caruciorNevalidat.Cantitate})";
                    isValidList = false;
                    break;
                }
                if (!CodProdus.TryParseCodProdus(caruciorNevalidat.CodProdus, out CodProdus codP))
                {
                    invalidReson = $"Cod Produs Invalid ({caruciorNevalidat.CodProdus})";
                    isValidList = false;
                    break;
                }
                if (!Adresa.TryParseAdresa(caruciorNevalidat.Adresa, out Adresa adresa))
                {
                    invalidReson = $"Adresa Invalida ({caruciorNevalidat.Adresa})";
                    isValidList = false;
                    break;
                }
                if (!Pret.TryParsePret(caruciorNevalidat.Pret, out Pret pret))
                {
                    invalidReson = $"Pret Invalid ({caruciorNevalidat.Pret})";
                    isValidList = false;
                    break;
                }
                CaruciorValidat CaruciorValid = new(codP, cantitate, adresa,pret);
                carucioareValidate.Add(CaruciorValid);
                pretTotal += Decimal.Parse(caruciorNevalidat.Pret);
            }
            if (isValidList)
            {
                return new CaruciorProduseValidat(carucioareValidate,pretTotal);
            }
            else
            {
                return new CaruciorProduseGol(Caruciornevalidat.Caruciorprod, invalidReson);
            }

        }

        public static ICaruciorProduse PublicaCarucior(ICaruciorProduse carut) => carut.Match(
            whenCaruciorProduseGol: caruciorgol => caruciorgol,
            whenCaruciorProduseNevalidat: caruciorNevalid => caruciorNevalid,
            whenCaruciorProdusePlatit: caruciorplat => caruciorplat,
            whenCaruciorProduseValidat: caruciorValid =>
            {
                StringBuilder csv = new();
                caruciorValid.CaruciorProd.Aggregate(csv, (export, cr) => export.AppendLine($"{cr.Codprodus.Value}, {cr.Cantitateprodus}, {cr.pret},{cr.adresa.Value}"));
                CaruciorProdusePlatit carutPlatit = new(caruciorValid.CaruciorProd, csv.ToString(), DateTime.Now, caruciorValid.PretProduse);


                return carutPlatit;
            });
    }
}
