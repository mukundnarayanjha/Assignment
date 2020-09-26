using Microsoft.AspNetCore.Builder;
using Assignment.API.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Assignment.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ErrorLoggingMiddlewareExtensions
    {
        public static void UseErrorLogging(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(err => err.Run(ErrorLogging.HandleAsync));
        }
    }
}
