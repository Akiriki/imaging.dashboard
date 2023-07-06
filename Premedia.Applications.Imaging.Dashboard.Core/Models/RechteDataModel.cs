namespace Premedia.Applications.Imaging.Dashboard.Core.Models;

public class RechteDataModel
{
    public string Profitcenter { get; set; }
    public long SchienenId { get; set; }
    public int GueltigkeitVor { get; set; }
    public int GueltigkeitNach { get; set; }
    public List<string>? Aktionskuerzel { get; set; } = new();

    // Auf Wunsch von Frank Hoffmann (XXXLutz) GueltigkeitVor und GueltigkeitNach getauscht
    public DateTime GueltigkeitBeginn
    {
        get { return DateTime.Now.AddDays(-GueltigkeitNach); }
    }

    public DateTime GueltigkeitEnde
    {
        get { return DateTime.Now.AddDays(GueltigkeitVor); }
    }

    public RechteDataModel ShallowCopy()
    {
        return (RechteDataModel)this.MemberwiseClone();
    }

    public void SetRechteForExternalUser(string profitcenter, long schienenId)
    {
        Profitcenter = profitcenter;
        SchienenId = schienenId;
        GueltigkeitVor = 0;
        GueltigkeitNach = 10000;
    }
}