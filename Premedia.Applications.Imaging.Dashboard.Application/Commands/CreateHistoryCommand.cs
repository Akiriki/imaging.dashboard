namespace Premedia.Applications.Imaging.Dashboard.Application.Commands
{
    public class CreateHistoryCommand
    {
        public string Action { get; set; }
        public string Field { get; set; }
        public string ErrorCode { get; set; }
        public string OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}