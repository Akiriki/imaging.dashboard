 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.ReadModels
{
    public class FilePathReadModel : BaseReadModel
    {
        public string WindowsPath { get; set; }
        public string MacPath { get; set; }
        public string EbvFileaction { get; set; }
    }
}