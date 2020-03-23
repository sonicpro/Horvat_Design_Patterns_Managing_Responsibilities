using M4_CompositePainters.Interfaces;
using System;

namespace M4_CompositePainters
{
    // Leaf component.
    public class Painter : IPainter
    {
        private double daysPerHouse;

        private string name;

        public Painter(string name, double daysPerHouse)
        {
            this.name = name;
            this.daysPerHouse = daysPerHouse;
        }

        public double Paint(double houses)
        {
            double totalDays = EstimateDays(houses);
            Console.WriteLine($"{name} painted {houses:N2} in {totalDays:N2} days");
            return totalDays;
        }

        public double EstimateDays(double housesCount)
        {
            return housesCount * this.daysPerHouse;
        }
    }
}
