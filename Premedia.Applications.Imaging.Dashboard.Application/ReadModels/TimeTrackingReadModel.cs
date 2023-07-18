using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.ReadModels
{
    public class TimeTrackingReadModel : BaseReadModel
    {
        public DateTime StartedOn { get; set; }
        public TimeSpan WorkingDuration { get; set; }
    }
}