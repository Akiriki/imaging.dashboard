using System.Net;
using Serilog;

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

    public static HttpResponseException NotFound(string value)
    {
        Log.Error(ErrorMessages.GetNotFoundMessage(value));
        return new HttpResponseException(ErrorMessages.GetNotFoundMessage(value), HttpStatusCode.NotFound);
    }

    public static HttpResponseException UnknownError(Exception exception)
    {
        if (exception is HttpResponseException error)
        {
            return error;
        }

        Log.Error(ErrorMessages.GetNoSubjectsFoundMessage(exception.Message));
        return new HttpResponseException(ErrorMessages.UnknownErrorMessage(), HttpStatusCode.InternalServerError);
    }
}