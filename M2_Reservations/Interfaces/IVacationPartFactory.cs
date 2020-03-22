// Abstract factory that collects all the methods of services providing different vacation parts.
// Must not know about the dependencies that provide the implementation of those methods.
// That way we can abstract the dependent class (VacationSpecificationBuilder) of the implementation details of the services it uses at compile time.

using System;

namespace Reservations.Interfaces
{
    public interface IVacationPartFactory
    {
        IVacationPart CreateHotelReservation(string town, string hotelName, DateTime arrivalDate,
            DateTime leaveDate);

        IVacationPart CreateFlight(string companyName, string source, string destination, DateTime date);

        IVacationPart CreateFerryBooking(string lineName, bool fromMainland, DateTime date);

        IVacationPart CreateDailyTrip(string tripName, DateTime date);

        IVacationPart CreateMassage(string salon, DateTime date);
    }
}
