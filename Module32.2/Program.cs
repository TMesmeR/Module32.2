using Modul32._2.Middleware;
using Module32._2.Context;
using Module32._2.Repocitorys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>();
builder.Services.AddScoped<IBlogDbRepository, BlogDbRepository>();
builder.Services.AddScoped<ILoggingDbRepository, LoggingDbRepository>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseMiddleware<LoggingMiddelware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapControllerRoute(
    name: "logs",
    pattern: "logs",
    defaults: new { controller = "Logs", action = "Index" }
);
app.Run();