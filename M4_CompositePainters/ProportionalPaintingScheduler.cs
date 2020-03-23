using M4_CompositePainters.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace M4_CompositePainters
{
    class ProportionalPaintingScheduler : IPaintingScheduler
    {
        public IEnumerable<(IPainter Painter, double HousesToPaint)> Organize(IEnumerable<IPainter> painters, double houses)
        {
            // Calculate the proportion of each subsidiary's velocity to the total velocity and give
            // that proportion of houses to that subsidiary.
            var overallVelocity = GetOverallVelocity(painters);
            var daysPerHouseDenominator = 1.0;

            return painters
                .Select(p => new
                {
                    Painter = p,
                    PainterVelocity = daysPerHouseDenominator / p.EstimateDays(daysPerHouseDenominator)
                })
                .Select(z => (z.Painter, HousesToPaint: houses * z.PainterVelocity / overallVelocity));
        }

        private double GetOverallVelocity(IEnumerable<IPainter> painters)
        {
            var daysPerHouseDenominator = 1.0;
            return painters.Aggregate(0.0, (current, next) => current + (daysPerHouseDenominator / next.EstimateDays(daysPerHouseDenominator)));
        }
    }
}
