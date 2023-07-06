using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public abstract class History:EntityObject
{
    public User Editor { get; set; }
    public string Action { get; set; }
    public string Field { get; set; }
    public string ErrorCode { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime ChangeTime { get; set; }
}

