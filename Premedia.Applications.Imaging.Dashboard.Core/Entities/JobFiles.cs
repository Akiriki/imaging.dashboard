using Premedia.Applications.Imaging.Dashboard.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class JobFiles:EntityObject
{

    public string SwitchJobField { get; set; }
    public string OriginalFilename { get; set; }
    public string EditedFilename { get; set; }
    public string FileExtension { get; set; }
    
    public Status Status { get; set; }
    public string FileProperties { get; set; }
    public string Thumbnail { get; set; }
    public string Activity { get; set; }
    public string StorageType { get; set; }
    public string Source { get; set; }
    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }

    
    //Realtions
    public Guid CreatorId { get; set; }
    public User Creator { get; set; } = null!;

    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;

    //public Guid FilePathId { get; set; }
    public FilePath FilePath { get; set; } = null!;

}

