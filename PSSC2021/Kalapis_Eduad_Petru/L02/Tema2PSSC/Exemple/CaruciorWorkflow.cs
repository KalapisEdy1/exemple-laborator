using System;
using Tema1PSSC.Domain;
using static Tema1PSSC.Domain.Carucior;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tema1PSSC.Domain.CaruciorPlatitEvent;
using static Tema1PSSC.CaruciorOperations;

namespace Tema1PSSC
{
    class CaruciorWorkflow
    {
        public ICaruciorPlatitEvent Execute(PublishCaruciorCommand command, Func<CodProdus, bool> checkProdusExists)
        {
            CaruciorProduseNevalidat caruciornevalidat = new CaruciorProduseNevalidat(command.InputCarucior);
            ICaruciorProduse produse = CaruciorProduseValid(checkProdusExists, caruciornevalidat);
            produse = PublicaCarucior(produse);

            return produse.Match(
                    whenCaruciorProduseGol: CaruciorGol => new CaruciorPlatitFaildEvent(CaruciorGol.Reason),
                    whenCaruciorProduseNevalidat: invalidGrades => new CaruciorPlatitFaildEvent("Neasteptata stare de nevalidare") as ICaruciorPlatitEvent,
                    whenCaruciorProduseValidat: validatedGrades => new CaruciorPlatitFaildEvent("Unexpected validated state"),
                    whenCaruciorProdusePlatit: publishedGrades => new CaruciorPlatitSuccededEvent(publishedGrades.Csv, publishedGrades.PretProduse, publishedGrades.PublishedDate)
                );
        }
    }
}
