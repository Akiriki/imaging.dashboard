using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class AdditionalFile:EntityObject
{
    public string Title { get; set; }

    //Relations
    public Guid CreatorId { get; set; }
    public User Creator { get; set; } = null!;

    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;

    public Guid FilePathId { get; set; }
    public FilePath FilePath { get; set; } = null!;
}

