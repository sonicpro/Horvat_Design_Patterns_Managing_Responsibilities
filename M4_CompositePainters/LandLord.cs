using System;
using System.Collections.Generic;
using System.Linq;

namespace M4_CompositePainters
{
    public class LandLord
    {
        private int totalHouses;

        // The dedicated painters
        private IEnumerable<Painter> painters;

        public LandLord(int totalHouses, IEnumerable<Painter> painters)
        {
            this.totalHouses = totalHouses;
            this.painters = painters;
        }

        public void MaintainHouses()
        {
            double housesPainted = 0.0;

            foreach(Painter p in painters)
            {
                housesPainted += p.PaintFor(totalHouses / TotalSpeedHousesPerDay());
            }

            Console.WriteLine($"\nPainted {housesPainted:0} houses.");
        }

        private double TotalSpeedHousesPerDay()
        {
            var daysPerHouseDenominator = 1;
            return painters.Aggregate(0.0, (current, next) => current + ((double)daysPerHouseDenominator / next.EstimateDays(daysPerHouseDenominator)));
        }

    }
}
