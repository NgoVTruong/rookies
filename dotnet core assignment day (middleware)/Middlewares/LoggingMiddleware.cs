using System.Diagnostics;

namespace dotnet_core_assignment_day__middleware_.Middlewares
{
    public class LoggingMiddeleWare
    {
        private readonly RequestDelegate _next;

        public LoggingMiddeleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            string requestInfo = "Scheme :" + request.Scheme
            + "\t Host :" + request.Host
            + "\t Path :" + request.Path
            + "\t QueryString :" + request.QueryString
            + "\t Body :" + request.Body;
            
            Debug.Write(requestInfo);
            File.WriteAllText("text.txt", requestInfo);

            await _next(context); 
        }
    }
}