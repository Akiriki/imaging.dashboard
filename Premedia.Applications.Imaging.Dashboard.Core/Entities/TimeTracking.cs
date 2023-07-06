using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public abstract class TimeTracking:EntityObject
{
    public User Editor { get; set; }
    public DateTime StartedOn { get; set; }
    public TimeSpan WorkingDuration { get; set; }
    public User CreatedBy { get; set; }
}

