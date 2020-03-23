using System;

namespace M4_CompositePainters
{
    class Program
    {
        // Program that calculates the total time to paint cetrain number of houses by a squad of painters.
        static void Main(string[] args)
        {
            LandLord owner = new LandLord(5, new Painter[] { new Painter("Ivan", 4), new Painter("Andrey", 5) });
            owner.MaintainHouses();
        }
    }
}
