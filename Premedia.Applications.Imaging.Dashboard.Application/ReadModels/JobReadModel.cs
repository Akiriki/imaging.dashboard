using Premedia.Applications.Imaging.Dashboard.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.ReadModels
{
    public class JobReadModel : BaseReadModel
    {
        public int ConsecutiveNumber { get; set; }
        public string Title { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid SwitchJobId { get; set; }
        public string JobInfo { get; set; }
        public OrderType OrderType { get; set; }
        public string Project { get; set; }
        public string EasyJob { get; set; }
        public BillingOption BillingOption { get; set; }
        public Status Status { get; set; }
    }
}