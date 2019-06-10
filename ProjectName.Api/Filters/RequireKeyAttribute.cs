using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using ProjectName.Common.Configuration;

namespace ProjectName.Api.Filters
{
    public class RequireKeyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var apiKey = ConfigurationManager.AppSettings["AppConfig:ApiKey"];
            var apiKeyHeader = context.HttpContext.Request.Headers["ApiKey"];

            if(string.IsNullOrEmpty(apiKeyHeader) || apiKey != apiKeyHeader)
                context.Result = new UnauthorizedResult();
        }
    }
}