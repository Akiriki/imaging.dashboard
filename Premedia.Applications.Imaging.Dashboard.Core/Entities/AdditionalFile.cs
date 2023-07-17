namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class AdditionalFile:EntityObject
{
    public string Title { get; set; }

    //Relations
    public Guid CreatorId { get; set; }
    public User? Creator { get; set; }

    public Guid JobId { get; set; }
    public Job? Job { get; set; }

    public FilePath? FilePath { get; set; }
}