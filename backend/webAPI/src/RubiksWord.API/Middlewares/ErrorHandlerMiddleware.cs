using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace RubiksWord.API.Middlewares;

/// <summary>
/// Global error handler.
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}
