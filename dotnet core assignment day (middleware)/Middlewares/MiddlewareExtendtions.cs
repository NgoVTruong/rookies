namespace dotnet_core_assignment_day__middleware_.Middlewares
{
    public static class MiddleWareExtendtions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddeleWare>();
        }
    }
} 