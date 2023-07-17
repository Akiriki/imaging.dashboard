using Premedia.Applications.Imaging.Dashboard.Core.Enums;
namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class Job:EntityObject
{
    
    public int ConsecutiveNumber { get;set; }
    public string Title { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime OrderDate { get; set;}
    public Guid SwitchJobId { get; set; }
    public string JobInfo { get; set; }
    public OrderType OrderType { get; set; }
    public string Project { get; set; }
    public string EasyJob { get; set; }
    public BillingOption BillingOption { get; set; }

    //Relations
    public ICollection<UpdateJobFilesCommand> JobFiles { get; set; }=new List<UpdateJobFilesCommand>();
    public ICollection<History> History { get; set; } = new List<History>();
    public ICollection<AdditionalFile> AdditionalFile { get; set; } = new List<AdditionalFile>();
    public ICollection<TimeTracking> TimeTracking { get; set; } = new List<TimeTracking>();

    public Guid CustomerId { get; set; }
    public User Customer { get; set; } = null!;

    public Guid CreatorId { get; set; }
    public User Creator { get; set; } = null!;

    public Guid? EditorId { get; set; }
    public User? Editor { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;



}

