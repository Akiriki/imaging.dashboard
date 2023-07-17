namespace Premedia.Applications.Imaging.Dashboard.Application.Commands
{
    public class CreateTimeTrackingCommand
    {
        public DateTime StartedOn { get; set; }
        public TimeSpan WorkingDuration { get; set; }
    }
}
