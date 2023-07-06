using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public abstract class AdditionalFile:EntityObject
{
    public string Title { get; set; }
    public string Filepath { get; set; }
    public User CreatedBy { get; set; }

}

