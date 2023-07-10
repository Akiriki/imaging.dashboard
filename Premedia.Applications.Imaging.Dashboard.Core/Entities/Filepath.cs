using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class FilePath : EntityObject
{
    
    public string WindowsPath { get; set; }
    public string MacPath { get; set; }

    public string EbvFileaction { get; set; }

    //Realtions
    public Guid JobFileId { get; set; }
    public JobFiles JobFiles { get; set; }
    public Guid AdditionalFileId { get; set; }
    public AdditionalFile AdditionalFile { get; set; }
}

