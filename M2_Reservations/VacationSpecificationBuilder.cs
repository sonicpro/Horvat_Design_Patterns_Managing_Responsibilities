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

        private readonly IHotelService hotelService;

        private readonly IHotelSelector hotelSelector;

        private readonly IAirplaneService airplaneService;

        #endregion

        public VacationSpecificationBuilder(DateTime arrivalDate, int totalNights,
            IHotelService hotelService,
            IHotelSelector hotelSelector,
            IAirplaneService airplaneService,
            string livingTown, string destinationTown)
        {
            this.arrivalDate = arrivalDate;
            this.totalNights = totalNights;
            this.hotelService = hotelService;
            this.hotelSelector = hotelSelector;
            this.airplaneService = airplaneService;
            this.livingTown = livingTown;
            this.destinationTown = destinationTown;
        }

        public VacationSpecification BuildVacation()
        {
            foreach (IVacationPart part in this.parts)
            {
                part.Purchase();
            }
            return new VacationSpecification(this.parts);
        }


        #region Methods that call services

        private void SelectHotel(string hotelName)
        {
            var hotelInfo = this.hotelSelector.SelectHotel(destinationTown, hotelName);
            this.parts.Add(hotelService.MakeBooking(hotelInfo, arrivalDate, arrivalDate.AddDays(totalNights)));
        }

        private void SelectFlight(string companyName)
        {
            // Round-trip selection
            var directFlight = this.airplaneService.SelectFlight(companyName,
                livingTown, destinationTown, arrivalDate);
            var returnFlight = this.airplaneService.SelectFlight(companyName,
                destinationTown, livingTown, arrivalDate.AddDays(totalNights));
            parts.Add(directFlight);
            parts.Add(returnFlight);
        }

        #endregion
    }
}
