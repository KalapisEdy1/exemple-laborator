using Tema1PSSC.Domain;
using System;
using System.Collections.Generic;
using static Tema1PSSC.Domain.Carucior;

namespace Tema1PSSC
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listaProduse = ReadListOfProduse().ToArray();
            CaruciorProduseGol caruciorGol = new(listaProduse);
            ICaruciorProduse result = CaruciorProduseValidat(caruciorGol);
            result.Match(
                whenCaruciorProduseGol: unvalidatedResult => caruciorGol,
                whenCaruciorProdusePlatit: publicatPlata => publicatPlata,
                whenCaruciorProduseNevalidat: nevalidResult => nevalidResult,
                whenCaruciorProduseValidat: validatedResult => CaruciorProdusePlatit(validatedResult)
            );

            Console.WriteLine("Hello World!");
        }

        private static List<CaruciorGol> ReadListOfProduse()
        {
            List<CaruciorGol> listaProduse = new();
            do
            {
                //read registration number and grade and create a list of greads
                var cod = ReadValue("Cod : ");
                if (string.IsNullOrEmpty(cod))
                {
                    break;
                }

                var cantitateprodus = ReadValue("Cantitate Produs: ");
                if (string.IsNullOrEmpty(cantitateprodus))
                {
                    break;
                }

                var adresa = ReadValue("Adresa: ");
                if (string.IsNullOrEmpty(adresa))
                {
                    break;
                }

                listaProduse.Add(new(cod, cantitateprodus, adresa));
            } while (true);
            return listaProduse;
        }

        private static ICaruciorProduse CaruciorProduseValidat(CaruciorProduseGol cosGol) =>
            random.Next(100) > 50 ?
            new CaruciorProduseNevalidat(new List<CaruciorGol>(), "Random errror")
            : new CaruciorProduseValidat(new List<CaruciorValidat>());

        private static ICaruciorProduse CaruciorProdusePlatit(CaruciorProduseValidat cosValidat) =>
            new CaruciorProdusePlatit(new List<CaruciorValidat>(), DateTime.Now);

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
