using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1PSSC.Domain
{
    class PublishCaruciorCommand
    {
        public PublishCaruciorCommand(IReadOnlyCollection<CaruciorNevalidat> inputCarucior)
        {
            InputCarucior = inputCarucior;
        }

        public IReadOnlyCollection<CaruciorNevalidat> InputCarucior { get; }
    }
}
