// Abstract factory that collects all the methods of services providing different vacation parts.

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
