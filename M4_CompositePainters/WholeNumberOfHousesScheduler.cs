using M4_CompositePainters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4_CompositePainters
{
    class WholeNumberOfHousesScheduler : IPaintingScheduler
    {
        public IEnumerable<(IPainter Painter, double HousesToPaint)> Organize(IEnumerable<IPainter> painters, double totalHouses)
        {
            IEnumerable<(IPainter Painter, double HousesToPaint)> schedule = CreateEmptySchedule(painters);

            while (totalHouses > 0.0)
            {
                double part = Math.Min(1.0, totalHouses); // Add for a whole house unless the remainder is > 0 and < 1. Add the required amoint of time in that case.
                schedule = this.Add(schedule, part);
                totalHouses -= part;
            }
            return schedule;
        }

        private IEnumerable<(IPainter Painter, double HousesToPaint)> Add(IEnumerable<(IPainter Painter, double HousesToPaint)> schedule, double part)
        {
            // Apply "best suited painter" algorithm. The algorithm is like the following:

            // 1. For every painter in the schedule add "house part" to the number of houses the painter already has.
            // 2. Calculate the time required to the resulting HousesToPaint for every painter / PaintingCompany.
            // 3. Choose the painter / company with the minimal resutling time for the "houses to paint" calculated on step 1.
            (IPainter Painter, double HousesToPaint) optimalPainter = schedule
                .Select(pair => (pair.Painter, HousesToPaint: pair.HousesToPaint + part))
                .OrderBy(pair => pair.Painter.EstimateDays(pair.HousesToPaint))
                .First();

            // 4. Drop the old line for the painter chosen on the step 3 and replace it with the new line.
            IEnumerable<(IPainter Painter, double HousesToPaint)> newSchedule =
                schedule.Where(pair => !object.ReferenceEquals(pair.Painter, optimalPainter.Painter))
                .Union(new[] { optimalPainter })
                .ToList();

            return newSchedule;
        }

        private IEnumerable<(IPainter Painter, double HousesToPaint)> CreateEmptySchedule(IEnumerable<IPainter> painters)
        {
            return painters.Select(p => (p, 0.0)).ToList();
        }
    }
}
