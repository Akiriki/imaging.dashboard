using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Premedia.Applications.Imaging.Dashboard.Core.Exceptions;
using Serilog;

namespace Premedia.Applications.Imaging.Dashboard.ActionFIlters;

public class ModelStateValidationFilter: IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];

        if (!context.ModelState.IsValid)
        {
            var modelStateErrors = new List<ModelStateException>();

            foreach (var modelStateKey in context.ModelState.Keys)
            {
                var modelStateValue = context.ModelState[modelStateKey];
                var modelStateError = new ModelStateException
                {
                    ModelStateKey = modelStateKey,
                    ModelStateErrors = modelStateValue.Errors.Select(e => e.ErrorMessage).ToArray()
                };
                modelStateErrors.Add(modelStateError);
            }

            context.Result = new UnprocessableEntityObjectResult(modelStateErrors);

            Log.Information($"Invalid model state for the object. controller: {controller}, action: {action}");
            var messages = new List<string>();
            foreach (var error in modelStateErrors)
                messages.Add($"{error.ModelStateKey}: {string.Join("\n", error.ModelStateErrors)}");
            Log.Information($"{string.Join("\n", messages)}");
        }
    }


    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}