using Reservations.Interfaces;
using System.Collections.Generic;

namespace Reservations
{
    class VacationSpecification
    {
        private IList<IVacationPart> parts;

        public VacationSpecification(IList<IVacationPart> parts)
        {
            this.parts = parts;
        }
    }
}