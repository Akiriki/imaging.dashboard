using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.ReadModels
{
    public class TimeTrackingReadModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartedOn { get; set; }
        public TimeSpan WorkingDuration { get; set; }
    }
}