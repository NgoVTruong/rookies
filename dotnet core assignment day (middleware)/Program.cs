using dotnet_core_assignment_day__middleware_.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseLoggingMiddleware();
app.Run();