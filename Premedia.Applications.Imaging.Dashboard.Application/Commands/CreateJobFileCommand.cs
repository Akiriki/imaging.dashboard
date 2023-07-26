using Premedia.Applications.Imaging.Dashboard.Core.Enums;

namespace Premedia.Applications.Imaging.Dashboard.Application.Commands
{
    public class CreateJobFileCommand
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
    }
}