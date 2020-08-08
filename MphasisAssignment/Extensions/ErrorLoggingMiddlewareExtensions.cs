using Microsoft.AspNetCore.Builder;
using MphasisAssignment.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace MphasisAssignment.Extensions
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
