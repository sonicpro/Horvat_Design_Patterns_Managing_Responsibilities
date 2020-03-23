using M4_CompositePainters.Interfaces;
using System;

namespace M4_CompositePainters
{
    class Program
    {
        // Program that calculates the total time to paint cetrain number of houses by a squad of painters.
        static void Main(string[] args)
        {
            var scheduler = new WholeNumberOfHousesScheduler();

            var smallPaintersCorporation = new PaintingCompany(
                new IPainter[]
                {
                    new Painter("Ivan", 4),
                    new Painter("Andrey", 5)
                },
                scheduler);

            var consolidatedPaintersCorporation = new PaintingCompany(
                new IPainter[]
                {
                    smallPaintersCorporation,
                    new Painter("Jon", 7)
                },
                scheduler);

            LandLord owner = new LandLord(14, consolidatedPaintersCorporation);
            owner.MaintainHouses();
        }
    }
}
