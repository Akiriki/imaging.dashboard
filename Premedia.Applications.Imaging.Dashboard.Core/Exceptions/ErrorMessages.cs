using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premedia.Applications.Imaging.Dashboard.Core.Exceptions;

public static class ErrorMessages
{
    public static string GetNotFoundMessage(string subject)
    {
        return $"{subject} could not be found.";
    }

    public static string GetNoSubjectsFoundMessage(string subject)
    {
        return $"No {subject}s were found for this user.";
    }

    public static string UnknownErrorMessage()
    {
        return $"An unknown error occoured. Please contact your administrator.";
    }
}
