using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.ReadModels
{
    public class ActivityReadModel : BaseReadModel
    {
        public string Customer { get; set; }
        public string ServiceType { get; set; }
        public string Quality { get; set; }
    }
}
