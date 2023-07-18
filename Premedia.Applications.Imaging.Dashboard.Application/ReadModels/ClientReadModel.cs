using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.ReadModels
{
    public class ClientReadModel : BaseReadModel
    {
        public string Email { get; set; }
        public string Shortcut { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}