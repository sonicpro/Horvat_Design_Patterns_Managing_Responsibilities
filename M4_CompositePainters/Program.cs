using M4_CompositePainters.Interfaces;
using System;

namespace M4_CompositePainters
{
    class Program
    {
        // Program that calculates the total time to paint cetrain number of houses by a squad of painters.
        static void Main(string[] args)
        {
            var smallPaintersCorporation = new PaintingCompany(
                new IPainter[]
                {
                    new Painter("Ivan", 4),
                    new Painter("Andrey", 5)
                });

            var consolidatedPaintersCorporation = new PaintingCompany(
                new IPainter[]
                {
                    smallPaintersCorporation,
                    new Painter("Jon", 7)
                });

            LandLord owner = new LandLord(14, consolidatedPaintersCorporation);
            owner.MaintainHouses();
        }
    }
}
