using System.Net;

namespace Premedia.Applications.Imaging.Dashboard.Core.Exceptions;

public class HttpResponseException : Exception
{
    public int Status { get; set; }
    public object Value { get; set; }

    public HttpResponseException(string message, HttpStatusCode statusCode)
    {
        Value = new
        {
            message
        };

        Status = (int)statusCode;
    }
}