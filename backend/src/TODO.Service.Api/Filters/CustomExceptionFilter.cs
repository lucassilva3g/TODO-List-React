using Microsoft.AspNetCore.Mvc.Filters;
using Todo.Service.Application.Settings.Exceptions;
using Todo.Service.Domain.Exceptions;
using Todo.Service.Domain.Resources;

namespace Todo.Service.Api.Filters;


public class CustomExceptionFilter : IExceptionFilter
{
    private readonly Messages _messages;
    private readonly ILogger<CustomExceptionFilter> _logger;

    private readonly bool _isDevelopment;

    private bool isInternal = true;

    public CustomExceptionFilter(Messages messages,
        ILogger<CustomExceptionFilter> logger,
        IWebHostEnvironment env)
    {
        _messages = messages;
        _logger = logger;
        _isDevelopment = env.IsDevelopment();
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogDebug("Treating exception...");
        _logger.LogDebug("The exception is {@exceptionType}...", context.Exception.GetType());

        MountValidationRequest(context);

        MountBadRequest(context);

        MountNotFound(context);

        MountUnauthorized(context);

        MountPersistence(context);

        MountForbidden(context);

        MountInternalServerError(context);

        _logger.LogDebug("Exception treated...");
    }

    private void MountValidationRequest(ExceptionContext context)
    {
        if (context.Exception is not FluentValidationException)
            return;

        var vex = context.Exception as FluentValidationException;

        isInternal = false;

        var objeto = new ResponseError(_messages.GetMessage(Messages.Exception.VALIDATION), true, vex.Failures);

        MountResponse(context, (int)HttpStatusCode.BadRequest, objeto);
    }

    private void MountBadRequest(ExceptionContext context)
    {
        if (context.Exception is not BusinessException)
            return;

        isInternal = false;

        var objeto = new ResponseError(context.Exception.Message);

        MountResponse(context, (int)HttpStatusCode.BadRequest, objeto);
    }

    private void MountNotFound(ExceptionContext context)
    {
        if (context.Exception is not NotFoundException)
            return;

        isInternal = false;

        var nfe = context.Exception as NotFoundException;

        var message = nfe.Message;

        if (nfe.IsDefaultMessage)
            message = string.Format(_messages.GetMessage(Messages.Exception.NOT_FOUND), nfe.Name, nfe.Key);

        var objeto = new ResponseError(message);

        MountResponse(context, (int)HttpStatusCode.NotFound, objeto);
    }

    private void MountUnauthorized(ExceptionContext context)
    {
        if (context.Exception is not AuthorizationException)
            return;

        isInternal = false;

        var ae = context.Exception as AuthorizationException;

        var message = ae.Message;

        if (ae.IsDefaultMessage)
            message = _messages.GetMessage(Messages.Exception.AUTHORIZATION);

        var objeto = new ResponseError(message);

        MountResponse(context, (int)HttpStatusCode.Unauthorized, objeto);
    }

    private void MountPersistence(ExceptionContext context)
    {
        if (context.Exception is not PersistenceException)
            return;

        isInternal = false;

        var objeto = new ResponseError(_messages.GetMessage(Messages.Exception.PERSISTENCE));

        MountResponse(context, (int)HttpStatusCode.InternalServerError, objeto);
    }

    private void MountForbidden(ExceptionContext context)
    {
        if (context.Exception is not ForbiddenException)
            return;

        isInternal = false;

        var fe = context.Exception as ForbiddenException;

        var message = fe.Message;

        if (fe.IsDefaultMessage)
            message = _messages.GetMessage(Messages.Exception.FORBIDDEN);

        var objeto = new ResponseError(message);

        MountResponse(context, (int)HttpStatusCode.Forbidden, objeto);
    }

    private void MountInternalServerError(ExceptionContext context)
    {
        if (!isInternal)
            return;

        var objeto = new ResponseError(context.Exception.Message);

        MountResponse(context, (int)HttpStatusCode.InternalServerError, objeto);
    }

    private void MountResponse(ExceptionContext context, int status, ResponseError responseError)
    {
        _logger.LogDebug("Mounting response...");

        context.HttpContext.Response.ContentType = "application/problem+json";
        context.HttpContext.Response.StatusCode = status;

        ProblemDetails problemDetails;

        if (!responseError.HasErrors)
        {
            _logger.LogDebug("Response hasn't errors...");

            problemDetails = new ProblemDetails
            {
                Instance = context.HttpContext.Request.Path,
                Status = status,
                Title = responseError.Message
            };

        }
        else
        {
            _logger.LogDebug("Response has errors...");

            problemDetails = new ValidationProblemDetails(responseError.Errors)
            {
                Instance = context.HttpContext.Request.Path,
                Status = status,
                Title = responseError.Message
            };
        }

        if (_isDevelopment)
        {
            _logger.LogInformation("Putting stackTrace in response...");

            problemDetails.Detail = context.Exception.StackTrace;
        }

        _logger.LogInformation("Response based on exception: {@ProblemDetails}", problemDetails);

        var result = new JsonResult(problemDetails);

        context.Result = result;
    }

    class ResponseError
    {
        public ResponseError(string message, bool hasErrors = false, Dictionary<string, string[]> errors = null)
        {
            Message = message;
            HasErrors = hasErrors;
            Errors = !hasErrors ? null : errors;
        }

        public string Message { get; set; }
        public bool HasErrors { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
    }
}
