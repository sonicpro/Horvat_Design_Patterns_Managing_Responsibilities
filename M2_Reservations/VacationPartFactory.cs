using Reservations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservations
{
    class VacationPartFactory : IVacationPartFactory
    {
        private readonly IHotelService hotelService;
        private readonly IHotelSelector hotelSelector;
        private readonly IAirplaneService airplaneService;

        public VacationPartFactory(IHotelService hotelService, IHotelSelector hotelSelector,
            IAirplaneService airplaneService)
        {
            this.hotelService = hotelService;
            this.hotelSelector = hotelSelector;
            this.airplaneService = airplaneService;
        }

        public IVacationPart CreateDailyTrip(string tripName, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IVacationPart CreateFerryBooking(string lineName, bool fromMainland, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IVacationPart CreateFlight(string companyName, string source, string destination, DateTime date)
        {
            return this.airplaneService.SelectFlight(companyName, source, destination, date);
        }

        public IVacationPart CreateHotelReservation(string town, string hotelName, DateTime arrivalDate, DateTime leaveDate)
        {
            var hotelInfo = this.hotelSelector.SelectHotel(town, hotelName);
            return hotelService.MakeBooking(hotelInfo, arrivalDate, leaveDate);
        }

        public IVacationPart CreateMassage(string salon, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
