using System.ComponentModel.DataAnnotations;

namespace Premedia.Applications.Imaging.Dashboard.Core.Entities;

public class Client:EntityObject
{
    public string Email { get; set; }
    public string Shortcut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}

