using Reservations.Interfaces;
using System;


// Concrete factory implementation for the VacationSpecificationBuilder. Collects "leaked dependencies" of VacationSpecificationBuilder.
// That way those dependencies does not leak to the consumers of VacationSpecificationBuilfer.

// Notice that in CreateHotelReservation(string, string, DateTime, DateTime) method this concrete factory isolates HotelService concrete product from
// the HotelSelector concrete product implementation details.

// The other possible option was to provide the other abstract IHotelInfoFactory that would provide the method
// "HotelInfo GetHotelInfo(string town, string hotelName)".
// That way we would have HotelSelector the dependency of the IHotelInfoFactory "concrete" implementation rather than dependency of this concrete factory.
// HotelService would no longer leaked into the VacationSpecificationBuilder "concrete product" implementation,
// it would rather leaked only to HotelSelector implementation.

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
