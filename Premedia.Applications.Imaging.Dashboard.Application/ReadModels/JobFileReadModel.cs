using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using Premedia.Applications.Imaging.Dashboard.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Application.ReadModels
{
    public class JobFileReadModel : BaseReadModel
    {
        public string SwitchJobField { get; set; }
        public string OriginalFilename { get; set; }
        public string EditedFilename { get; set; }
        public string FileExtension { get; set; }
        public Status Status { get; set; }
        public string FileProperties { get; set; }
        public string Thumbnail { get; set; }
        public string StorageType { get; set; }
        public string Source { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public JobReadModel Job { get; set; }
        public FilePathReadModel FilePath { get; set; }
        public ActivityReadModel? Activity { get; set; }
    }
}