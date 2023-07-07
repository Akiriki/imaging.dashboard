using Premedia.Applications.Imaging.Dashboard.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class Job:EntityObject
{
    
    public int ConsecutiveNumber { get;set; }
    public string Titel { get; set; }
    public User Customer { get; set; }
    public JobFiles JobFiles { get; set; } 
    public AdditionalFile AdditionalFile { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime OrderDate { get; set;}
    public Guid SwitchJobId { get; set; }
    public string JobInfo { get; set; }
    public TimeTracking TimeTracking { get; set; }
    //public OrderType OrderType { get; set; }
    public User? Editor { get; set; }
    public string Project { get; set; }
    public bool EasyJob { get; set; }
    //public BillingOption BillingOption { get; set; }
    public History Histories { get; set; }
    public User CreatedBy { get; set; }




}

