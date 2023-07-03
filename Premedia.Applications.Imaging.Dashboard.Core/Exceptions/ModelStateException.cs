namespace Premedia.Applications.Imaging.Dashboard.Core.Exceptions;

public class ModelStateException
{
    public string ModelStateKey { get; set; }
    public string[] ModelStateErrors { get; set; }
}