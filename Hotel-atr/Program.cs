using Serilog;

var builder = WebApplication.CreateBuilder(args);

Host.CreateDefaultBuilder(args);
builder.Host.UseSerilog();
//builder.Host.ConfigureLogging(logging =>
//{
//    //logging.ClearProviders();
//    //logging.AddDebug();
//    //logging.AddConsole();
//    //logging.AddEventLog();

//    logging.AddSeq();
//});

// Add services to the container.
builder.Services.AddControllersWithViews();

Log.Logger = new LoggerConfiguration()
    //.WriteTo.Seq("http://localhost:5341/")
    .WriteTo.File("Logs/log.txt",
    rollingInterval:RollingInterval.Day)
    .CreateLogger();

builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
