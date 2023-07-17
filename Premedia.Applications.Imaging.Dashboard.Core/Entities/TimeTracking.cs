using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class TimeTracking:EntityObject
{
    
    public DateTime StartedOn { get; set; }
    public TimeSpan WorkingDuration { get; set; }


    //Relations
    public Guid CreatorId { get; set; }
    public User Creator { get; set; } = null!;

    public Guid EditorId { get; set; }
    public User Editor { get; set; } = null!;

    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}

