using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exp)
            {
                object response = null;
                response = new
                {
                    message = "Internal server error"
                };
                var statusCode = StatusCodes.Status500InternalServerError;


                httpContext.Response.ContentType = "application/json";

                switch (exp)
                {
                    case UnauthorizedUseCaseException:
                        statusCode = StatusCodes.Status403Forbidden;
                        response = new {
                            message = "You are not allowed to execute this operation."
                        };
                        break;
                    case EntityNotFoundException e:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = e.Message
                        };
                        break;
                    case EntityAlreadyExists e:
                        statusCode = StatusCodes.Status409Conflict;
                        response = new
                        {
                            message = "Entity already exists."
                        };
                        break;
                }

                httpContext.Response.StatusCode = statusCode;

                if (response != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }

                await Task.FromResult(httpContext.Response);
            }
        }
    }
}
