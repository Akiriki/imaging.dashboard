using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class User:EntityObject
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    //Realtions
    public ICollection<History> History { get; set; }=new List<History>();
    public ICollection<TimeTracking> TimeTrackingCreator { get; set; } = new List<TimeTracking>();
    public ICollection<TimeTracking> TimeTrackingEditor { get; set; } = new List<TimeTracking>();
    public ICollection<Job> JobsAsEditor { get; set; } = new List<Job>();
    public ICollection<Job> JobsAsCreator { get; set; } = new List<Job>();
    public ICollection<Job> JobsAsCustomer { get; set; } = new List<Job>();

    public ICollection<UpdateJobFilesCommand> JobFiles { get; set; } = new List<UpdateJobFilesCommand>();
    public ICollection<AdditionalFile> AdditionalFile { get; set; } = new List<AdditionalFile>();

}

