using M4_CompositePainters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4_CompositePainters
{
    public class LandLord
    {
        private int totalHouses;

        // The dedicated painters
        private IPainter painter;

        public LandLord(int totalHouses, IPainter painter)
        {
            this.totalHouses = totalHouses;
            this.painter = painter;
        }

        public void MaintainHouses()
        {
            double days = this.painter.Paint(this.totalHouses);

            Console.WriteLine($"\nPainted {totalHouses:0} houses in {days:N2} days.");
        }
    }
}
