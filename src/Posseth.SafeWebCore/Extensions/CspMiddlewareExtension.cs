// Michel Posseth 2024/06/22 YYYY/MM/DD
using System;
using Microsoft.AspNetCore.Builder;
namespace Posseth.SafeWebCore
{
    public static class CspMiddlewareExtensions
    {
        public static IApplicationBuilder UseCsp(this IApplicationBuilder builder, Action<CspBuilder> configure)
        {
            var cspBuilder = new CspBuilder();
            configure(cspBuilder);
            return builder.UseMiddleware<CspMiddleware>(cspBuilder);
        }
    }
}