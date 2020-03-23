using M4_CompositePainters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4_CompositePainters
{
    // Composite component.
    public class PaintingCompany : IPainter
    {
        private IEnumerable<IPainter> painters;

        public PaintingCompany(IEnumerable<IPainter> painters)
        {
            this.painters = painters;
        }

        public double EstimateDays(double numberOfHouses)
        {
            return numberOfHouses / GetOverallVelocity();
        }

        public double Paint(double houses)
        {
            // Calculate the proportion of each subsidiary's velocity to the total velocity and give
            // that proportion of houses to that subsidiary.
            var overallVelocity = GetOverallVelocity();
            var daysPerHouseDenominator = 1.0;

            // For "self-employed Jon the velocity is 1/7 (0.143 house/day)
            // For "smallPaintingCompany" the overall velocity is 0.45 (0.2 house/day Andrey's velocity + 0.25 house/day Ivan's velocity).
            var velocities = this.painters
                .Select(p => new
                {
                    Painter = p,
                    PainterVelocity = daysPerHouseDenominator / p.EstimateDays(daysPerHouseDenominator)
                });

            // For every constituent of the painters list its Paint(HousesToPaint) method returns the same value,
            // becuase the passed HousesToPaint paramenter has calculated based on the constituent overall speed,
            // we can take First() row value as the overall mainenance duration.
            double totalDays = velocities.Select(z => new
                {
                    z.Painter,
                    HousesToPaint = houses * z.PainterVelocity / overallVelocity
                })
                .Select(constituent => constituent.Painter.Paint(constituent.HousesToPaint))
                .ToList() // To get every leaf painter Paint() method executed.
                .First();

            return totalDays;
        }

        private double GetOverallVelocity()
        {
            var daysPerHouseDenominator = 1.0;
            return painters.Aggregate(0.0, (current, next) => current + (daysPerHouseDenominator / next.EstimateDays(daysPerHouseDenominator)));
        }
    }
}
