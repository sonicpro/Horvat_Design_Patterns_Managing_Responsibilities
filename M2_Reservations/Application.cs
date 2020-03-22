using Reservations.Interfaces;
using System;

namespace Reservations
{
    class Application
    {
        private IVacationPartFactory partFactory;

        public Application(IVacationPartFactory partFactory)
        {
            this.partFactory = partFactory;
        }

        public void Run()
        {
            VacationSpecificationBuilder builder =
                new VacationSpecificationBuilder(new DateTime(2020, 9, 11), 14, "Hometown", "Kemer", this.partFactory);

            builder.SelectHotel("Small one");
            builder.SelectRoundTrip("Noisy one");

            VacationSpecification spec = builder.BuildVacation();
        }
    }
}
