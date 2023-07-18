using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.ReadModels
{
    public abstract class BaseReadModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
