using System.Net;

namespace OcelotApiGateway.Services.Handlers
{
    public class RequestHandler : DelegatingHandler
    {
        private readonly ILogger<RequestHandler> _logger;

        public RequestHandler(ILogger<RequestHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            var c = request.Content is not null ? await request.Content.ReadAsStringAsync() : string.Empty;

            // Do stuff and optionally call the base handler...
            _logger.LogInformation($"request: {c}");

            // set HttpResponseMessage
            //var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            //{
            //    Content = new StringContent("Hello!")
            //};
            //var tsc = new TaskCompletionSource<HttpResponseMessage>();
            //tsc.SetResult(response);   // Also sets the task state to "RanToCompletion"
            //return await tsc.Task;

            //return await base.SendAsync(request, token);

            HttpResponseMessage response = await base.SendAsync(request, token);
            response.Headers.Add("X-Custom-Header", "This is my custom header.");
            return response;
        }
    }
}
