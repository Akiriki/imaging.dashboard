using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities
{
    public class Activity : EntityObject
    {
        public string Customer { get; set; }
        public string ServiceType { get; set; }
        public string Quality { get; set; }

        //Relations
        public List<JobFiles> JobFiles { get; set; }
    }
}
