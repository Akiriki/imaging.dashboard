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
    public ICollection<TimeTracking> TimeTracking { get; set; } = new List<TimeTracking>();
    public ICollection<Job> Job { get; set; } = new List<Job>();
    //public ICollection<JobFiles> JobFiles { get; set; } = new List<JobFiles>();
   // public ICollection<AdditionalFile> AdditionalFile { get; set; } = new List<AdditionalFile>();

}

