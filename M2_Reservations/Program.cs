using Reservations.Services;

namespace Reservations
{
    class Program
    {
        static void Main(string[] args)
        {
            new Application(
                new VacationPartFactory(
                    new HotelService(),
                    new HotelSelector(),
                    new AirplaneService()))
            .Run();
        }
    }
}
