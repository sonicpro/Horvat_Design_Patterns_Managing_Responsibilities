using System;

namespace M4_CompositePainters
{
    class Program
    {
        // Program that calculates the total time to paint cetrain number of houses by a squad of painters.
        static void Main(string[] args)
        {
            LandLord owner = new LandLord(14);
            owner.MaintainHouses();
        }
    }
}
