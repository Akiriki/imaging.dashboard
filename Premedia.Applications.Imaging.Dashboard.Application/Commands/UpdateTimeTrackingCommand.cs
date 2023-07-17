using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.Commands
{
    public class UpdateTimeTrackingCommand
    {
        public DateTime StartedOn { get; set; }
        public TimeSpan WorkingDuration { get; set; }
    }
}
