using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using Money_Exchange.API.ViewModels.Response;

namespace Money_Exchange.API.Infraestructure.ExceptionHandler
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var messageException = (exception == null || string.IsNullOrEmpty(exception.Message)) ? "Contact the system administrator" : exception.Message;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Internal Server Error from Middleware.");
            builder.AppendLine("Exception: " + messageException);
            builder.AppendLine("=============================================");
            builder.AppendLine("Stacktrace: ");
            builder.AppendLine(exception.StackTrace);

            var innerEx = exception.InnerException;
            while (innerEx != null)
            {
                builder.AppendLine("InnerException: " + innerEx.Message);
                builder.AppendLine("Stacktrace: ");
                builder.AppendLine(innerEx.StackTrace);
                innerEx = innerEx.InnerException;
            }

            return httpContext.Response.WriteAsync(
                new ResponseEntity<String> { code = httpContext.Response.StatusCode, status = false, message = messageException, messageException = builder.ToString(), result = null }.ToString());
        }
    }
}
