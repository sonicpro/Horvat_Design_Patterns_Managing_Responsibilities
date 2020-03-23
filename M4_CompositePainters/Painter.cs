using System;

namespace M4_CompositePainters
{
    public class Painter
    {
        private int daysPerHouse;

        private string name;

        public Painter(string name, int daysPerHouse)
        {
            this.name = name;
            this.daysPerHouse = daysPerHouse;
        }

        public double PaintFor(double totalDays)
        {
            double totalHouses = totalDays / this.daysPerHouse;
            Console.WriteLine($"{name} painted {totalHouses:N2} in {totalDays:N2} days");
            return totalHouses;
        }

        public int EstimateDays(int housesCount)
        {
            return housesCount * this.daysPerHouse;
        }
    }
}
