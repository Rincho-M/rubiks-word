using Microsoft.AspNetCore.Builder;
using RubiksWord.API.Middlewares;

namespace RubiksWord.API.Extensions;

public static class MiddlewaresExtensions
{
    /// <summary>
    /// Add global error handler middleware to the pipeline.
    /// </summary>
    public static IApplicationBuilder UseGlobalErrorHandler(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
