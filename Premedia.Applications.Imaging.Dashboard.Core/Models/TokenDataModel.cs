using Premedia.Applications.Imaging.Dashboard.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class TokenDataModel
{
    public TokenDataModel()
    {
    }

    public TokenDataModel(string kurzzeichen, string sprachkennzeichen, bool superuser)
    {
        Kurzzeichen = kurzzeichen;
        Sprachkennzeichen = sprachkennzeichen;
        Superuser = superuser;
    }

    public long? SessionId { get; set; }

    public DateTime? ErstelltAm { get; set; }
    public string Kurzzeichen { get; set; }
    public string? Sprachkennzeichen { get; set; }
    public bool? Superuser { get; set; }
    public bool IsSchienenAdmin { get; set; }
    public bool? IsExternalUser { get; set; }

    public List<string> Filialen { get; set; } = new();
    public List<RechteDataModel> Rechte { get; set; } = new();

    [NotMapped]
    public bool IsSuperUser
    {
        get
        {
            // Eigene Property falls es zusätzliche Bedingungen gibt
            return Superuser ?? false;
        }
    }

    [NotMapped]
    public bool IsMitbewerberAllowed
    {
        get { return true; }
    }

    [NotMapped]
    public bool IsPdfDownloadAllowed
    {
        get
        {
            // Anforderung von Frank Hoffmann 09.02.2022: Downloadfeature aktiveren bei Superuser = true oder wenn in den Filialen ein "00" oder "D00" vorkommt
            return IsExternalUser == true ||  IsSuperUser || Filialen.Any(x => x.Contains("00") || x.Contains("D00"));
        }
    }
}