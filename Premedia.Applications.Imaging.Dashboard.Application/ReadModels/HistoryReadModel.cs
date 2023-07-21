using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.ReadModels
{
    public class HistoryReadModel : BaseReadModel
    {
        public string Action { get; set; }
        public string Field { get; set; }
        public string ErrorCode { get; set; }
        public string OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime ChangeTime { get; set; }
        public JobReadModel Job { get; set; }
    }
}