using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
   public interface IInsuranceMetrics
    {
        TimeSpan TimeSpeeding { get; set; }
        int TimesOutOfLane { get; set; }
        int RollingStops { get; set; }
        int TimesTailgating { get; set; }
    }
}
