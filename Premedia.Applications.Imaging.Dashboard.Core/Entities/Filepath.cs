using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public abstract class Filepath:EntityObject
{
    
    public string WindowsPath { get; set; }
    public string MacPath { get; set; }

    public string EbvFileaction { get; set; }
}

