
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoronaApp.Api.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class HandlerErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<HandlerErrorMiddleware> _ilogger;
    public HandlerErrorMiddleware(RequestDelegate next, ILogger<HandlerErrorMiddleware> ilogger)
    {
        _ilogger = ilogger;
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
            if (httpContext.Response.StatusCode > 400 && httpContext.Response.StatusCode < 500)
            {
                throw new Exception("Not Found the page rong url" + httpContext.Request.Body.Position);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
        catch (Exception ex)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";
            _ilogger.Log(LogLevel.Error, ex.Message);
            switch (ex)
            {
                case ArgumentNullException e:
                    // custom application error
                    await response.WriteAsync("Oppps... \n the argument {e.Message} is null!");
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    // not found error
                    await response.WriteAsync("Oppps... \n Page Not Found!");
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // unhandled error
                    await response.WriteAsync("Oppps... \n we are trying to fix the problem!");
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class HandleErrorMiddlewareExtensions
{
    public static IApplicationBuilder UseHandleErrorMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HandlerErrorMiddleware>();
    }
}


