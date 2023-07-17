﻿
namespace Premedia.Applications.Imaging.Dashboard.Application.Commands
{
    public class UpdateTimeTrackingCommand
    {
        public Guid Id { get; set; }
        public DateTime StartedOn { get; set; }
        public TimeSpan WorkingDuration { get; set; }
    }
}