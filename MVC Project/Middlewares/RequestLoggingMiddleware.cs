namespace MVC_Project.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath = "request_log.txt";

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            var user = context.User.Identity?.IsAuthenticated == true
                ? context.User.Identity.Name
                : "Anonymous";
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var logEntry = $"[{time}] Path: {path}, User: {user}";

            Console.WriteLine(logEntry);
            await File.AppendAllTextAsync(_logFilePath, logEntry + Environment.NewLine);

            await _next(context);
        }
    }

}
