using System;
using System.Collections.Generic;
using System.Text;

namespace M4_CompositePainters.Interfaces
{
    // Represents Component interface from Composite pattern.
    public interface IPainter
    {
        double Paint(double numberOfHouses);

        double EstimateDays(double numberOfHouses);
    }
}
