namespace Premedia.Applications.Imaging.Dashboard.Application.Commands
{
    public class UpdateClientCommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Shortcut { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}