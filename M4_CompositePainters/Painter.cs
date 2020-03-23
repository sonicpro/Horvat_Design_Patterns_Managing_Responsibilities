using System;

namespace M4_CompositePainters
{
    public class Painter
    {
        private int daysPerHouse;

        public Painter(int daysPerHouse)
        {
            this.daysPerHouse = daysPerHouse;
        }

        public void Paint(int totalHouses)
        {
            Console.WriteLine($"Painting {totalHouses} in {totalHouses * daysPerHouse} days");
        }
    }
}
