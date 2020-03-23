using System.Collections.Generic;

namespace M4_CompositePainters.Interfaces
{
    public interface IPaintingScheduler
    {
        IEnumerable<(IPainter Painter, double HousesToPaint)> Organize(IEnumerable<IPainter> painters, double totalHouses);
    }
}
