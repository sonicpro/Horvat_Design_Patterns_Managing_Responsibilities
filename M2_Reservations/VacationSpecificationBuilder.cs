using Reservations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservations
{
    class VacationSpecificationBuilder
    {
        private readonly DateTime arrivalDate;

        private readonly int totalNights;

        private IList<IVacationPart> parts = new List<IVacationPart>();

        private readonly string livingTown;

        private readonly string destinationTown;

        #region Dependencies

        IVacationPartFactory partFactory;

        #endregion

        public VacationSpecificationBuilder(DateTime arrivalDate, int totalNights,
            string livingTown, string destinationTown, IVacationPartFactory partFactory)
        {
            this.arrivalDate = arrivalDate;
            this.totalNights = totalNights;
            this.livingTown = livingTown;
            this.destinationTown = destinationTown;
            this.partFactory = partFactory;
        }

        public VacationSpecification BuildVacation()
        {
            foreach (IVacationPart part in this.parts)
            {
                part.Reserve();
            }
            return new VacationSpecification(this.parts);
        }


        #region Methods that call methods of abstract factory instead of dependency services

        public void SelectHotel(string hotelName)
        {
            var hotelBooking = this.partFactory.CreateHotelReservation(destinationTown, hotelName,
                arrivalDate, arrivalDate.AddDays(totalNights));
            this.parts.Add(hotelBooking);
        }

        public void SelectRoundTrip(string companyName)
        {
            parts.Add(CreateFlightToDestination(companyName));
            parts.Add(CreateFlightBack(companyName));
        }


        private IVacationPart CreateFlightToDestination(string companyName)
        {
            return this.partFactory.CreateFlight(companyName,
                livingTown, destinationTown, arrivalDate);
        }

        private IVacationPart CreateFlightBack(string companyName)
        {
            return this.partFactory.CreateFlight(companyName,
                destinationTown, livingTown, arrivalDate.AddDays(totalNights));
        }

        #endregion
    }
}
