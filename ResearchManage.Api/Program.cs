using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ResearchManage.Application;
using ResearchManage.Application.Middleware;
using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Infrustructure;
using ResearchManage.Infrustructure.Data;
using ResearchManage.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Swagger
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion


#region DbContext
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region Dependencies

builder.Services.AddInfrastructureDependencies();
builder.Services.AddServicesDependencies();
builder.Services.AddApplicationDependencies()
                 .AddServicesRegistreration();

#endregion

#region Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    //Password Settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    //Lockout Settings
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<ApplicationDBContext>()
.AddDefaultTokenProviders();
#endregion

#region Localization

builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt => opt.ResourcesPath = "");
builder.Services.Configure<RequestLocalizationOptions>(option =>
{
    List<CultureInfo> supportedCulture = new List<CultureInfo>
{
    new CultureInfo("en-US"),
    new CultureInfo("ar-EG")
};
    option.DefaultRequestCulture = new RequestCulture("en-US");
    option.SupportedCultures = supportedCulture;
    option.SupportedUICultures = supportedCulture;


});

#endregion

#region AllowCORS

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
});
#endregion



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Localization Middleware
var optionsLz = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (optionsLz != null)
    app.UseRequestLocalization(optionsLz.Value);
#endregion

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
