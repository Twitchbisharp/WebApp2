using Microsoft.EntityFrameworkCore;
using WebApp2.DAL;
using WebApp2.Models;
using Serilog;
using Serilog.Events;
using MyShop.DAL;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("FlashcardDbContextConnection") ?? throw new InvalidOperationException("Connection string 'FlashcardDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling =
    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<FlashcardDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:FlashcardDbContextConnection"]);
});


//OLD
//builder.Services.AddDefaultIdentity<IdentityUser>()

//.AddEntityFrameworkStores<FlashcardDbContext>();




//NEW
/*
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    //Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 6;

    //Lockout
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    //User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<FlashcardDbContext>()
//.AddDefaultUI()
.AddDefaultTokenProviders();
*/
builder.Services.AddScoped<IFlashcardRepository, FlashcardRepository>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IContributerRepository, ContributerRepository>();

builder.Services.AddRazorPages();
//OLD
builder.Services.AddSession();

//NEW
/*
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(1800); //30 min
    options.Cookie.IsEssential = true;
});
*/

var loggerConfiguration = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File($"Logs/app_{DateTime.Now:yyyyMMdd_HHmmss}.log");

loggerConfiguration.Filter.ByExcluding(e => e.Properties.TryGetValue("SourceContext", out var value) &&
                            e.Level == LogEventLevel.Information &&
                            e.MessageTemplate.Text.Contains("Executed DbCommand"));

var logger = loggerConfiguration.CreateLogger();
builder.Logging.AddSerilog(logger);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DBInit.Seed(app);
}

app.UseStaticFiles();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

//app.UseRouting();

app.UseAuthentication();



app.MapDefaultControllerRoute();
app.MapRazorPages();



app.Run();
