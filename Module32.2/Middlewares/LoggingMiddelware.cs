using Microsoft.EntityFrameworkCore;
using Module32._2.Models;
using Module32._2.Repocitorys;

namespace Modul32._2.Middleware;

public class LoggingMiddelware
{
    private readonly RequestDelegate _next;
    
    public LoggingMiddelware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, ILoggingDbRepository repo)
    {
        LogConsole(context);
        await LogFileAsync(context);
        await LogDatabaseAsync(context, repo);
        await _next.Invoke(context);
        
    }
    private void LogConsole(HttpContext context)
    {
        Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
    }
    private async Task LogFileAsync(HttpContext context)
    {
        string longMessage =
            $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path} {Environment.NewLine}";
        string logFilePath = Path.Combine(Directory.GetCurrentDirectory(),"logs", "log.txt");
     
        lock (new object())
        {
             File.AppendAllTextAsync(logFilePath, longMessage);
        }
    }
    private async Task LogDatabaseAsync(HttpContext context, ILoggingDbRepository repository)
    {
        var request = new Request
        {
            Url = $"{context.Request.Host.Value + context.Request.Path}"
        };

        await repository.LogRequest(request);
    }
}