using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.Commands
{
    public class UpdateActivityCommand
    {
        public Guid Id { get; set; }
        public string Customer { get; set; }
        public string ServiceType { get; set; }
        public string Quality { get; set; }
    }
}
