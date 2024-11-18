using Microsoft.AspNetCore.Antiforgery;

namespace OcelotApiGateway.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly IAntiforgery _antiforgery;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, 
            //IAntiforgery antiforgery, 
            ILogger<CustomMiddleware> logger)
        {
            _next = next;
            //_antiforgery = antiforgery;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            //if (HttpMethods.IsPost(context.Request.Method))
            //{
            //    await _antiforgery.ValidateRequestAsync(context);
            //}

            _logger.LogInformation($"middlewares");
            var ocRequestId = context.Items["RequestId"];
            if (context.Items["RequestId"] is not null)
            {
                context.Response.Headers["RequestId"] = context.Items["RequestId"]!.ToString();
            }
            await _next(context);
        }
    }
}
