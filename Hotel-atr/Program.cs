using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using Serilog;
using System.Globalization;

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

builder.Services
    .AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.Configure<RequestLocalizationOptions>
    (options =>
    {
        var supportCulture = new[]
        {
            new CultureInfo("kk-KZ"),
            new CultureInfo("ru-RU"),
            new CultureInfo("en-US")
        };
        options.DefaultRequestCulture = new RequestCulture("kk-KZ", "kk-KZ");
        options.SupportedCultures = supportCulture;
        options.SupportedUICultures = supportCulture;
    });

builder.Services.AddLocalization(options =>
    options.ResourcesPath = "Resources");

Log.Logger = new LoggerConfiguration()
    //.WriteTo.Seq("http://localhost:5341/")
    .WriteTo.File("Logs/log.txt",
    rollingInterval:RollingInterval.Day)
    .CreateLogger();

builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);

builder.Services.AddAuthentication
    (CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.Cookie.Name = ".AspNetCore.HotelAtr.Cookies";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(1);
        option.SlidingExpiration = true;
        option.LoginPath = "/Home/Login";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

var locOptions = app.Services
    .GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
