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

        private IPaintingScheduler scheduler;

        public PaintingCompany(IEnumerable<IPainter> painters, IPaintingScheduler scheduler)
        {
            this.painters = painters;
            this.scheduler = scheduler;
        }

        public double EstimateDays(double numberOfHouses)
        {
            return scheduler.Organize(painters, numberOfHouses)
                .Select(t => t.Painter.EstimateDays(t.HousesToPaint))
                .First();
        }

        public double Paint(double houses)
        {
            // "constituent" is either a paining company or a painter.
            return scheduler.Organize(this.painters, houses)
                .Select(constituent => constituent.Painter.Paint(constituent.HousesToPaint))
                .ToList() // To get every leaf painter Paint() method executed.
                .First();
        }
    }
}
