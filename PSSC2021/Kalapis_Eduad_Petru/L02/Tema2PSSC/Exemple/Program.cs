using Tema1PSSC.Domain;
using System;
using System.Collections.Generic;
using static Tema1PSSC.Domain.Carucior;
using static Tema1PSSC.Domain.CaruciorPlatitEvent;

namespace Tema1PSSC
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var Produse = ReadListOfProduse().ToArray();
            PublishCaruciorCommand command = new(Produse);
            CaruciorWorkflow workflow = new CaruciorWorkflow();
            var result = workflow.Execute(command,(coddProdus)=>true);
            result.Match(
                    whenCaruciorPlatitFaildEvent: @event =>
                    {
                        Console.WriteLine($"Plata nu sa efectuat: {@event.Reason}");
                        return @event;
                    },
                    whenCaruciorPlatitSuccededEvent: @event =>
                    {
                        Console.WriteLine($"Plata achitata.");
                        Console.WriteLine(@event.Csv);
                        Console.WriteLine("Pretul total:" + @event.PretProdus);
                        Console.WriteLine("Data " + @event.PublishedDate);
                        return @event;
                    }
                );

            Console.WriteLine("Hello World!");
        }

        private static List<CaruciorNevalidat> ReadListOfProduse()
        {
            List<CaruciorNevalidat> listaProduse = new();
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

                var pret = ReadValue("Adresa: ");
                if (string.IsNullOrEmpty(pret))
                {
                    break;
                }

                listaProduse.Add(new(cod, cantitateprodus, adresa,pret));
            } while (true);
            return listaProduse;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
