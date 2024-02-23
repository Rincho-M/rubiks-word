using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RubiksWord.API.Middlewares;

/// <summary>
/// Global error handler.
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException e)
        {
            HandleException(context, e, HttpStatusCode.BadRequest);
        }
        catch (Exception e)
        {
            HandleException(context, e, HttpStatusCode.InternalServerError);
        }
    }

    private void HandleException(HttpContext context, Exception e, HttpStatusCode statusCode)
    {
        _logger.LogError(e, e.Message);
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "text/plain";
        context.Response.WriteAsync($"{e.Message}\n\n{e.StackTrace}");
    }
}
