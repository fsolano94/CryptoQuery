using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CryptoQuery.Api.Exceptions
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            //Prepare the exception details in a string.
            var sb = new StringBuilder();
            sb.AppendLine(context.Exception.Message);
            sb.AppendLine(context.Exception.StackTrace);

            //Log the string here
            _logger.LogError(sb.ToString());

            //Notify Here by sending the string

            var status = HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var result = Result.Fail("An unexpected error has occurred.");

            response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
