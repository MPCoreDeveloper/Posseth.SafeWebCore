// Michel Posseth 2024/06/22 YYYY/MM/DD
using Microsoft.AspNetCore.Http;
namespace Posseth.SafeWebCore
{
    public class CspMiddleware(RequestDelegate next, CspBuilder builder)
    {
        private readonly RequestDelegate _next = next;
        private readonly string _policy = builder.ToString();

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Content-Security-Policy", _policy);
            await _next(context);
        }
    }
}

// Extension method for adding the middleware

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.UseCsp(csp =>
//{
//    csp.AddDirective("default-src", "'self'")
//       .AddDirective("script-src", "'self' https://trustedscripts.example.com");
//    // Add more directives as needed
//});

//app.MapGet("/", () => "Hello World!");

//app.Run();
