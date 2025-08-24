using Microsoft.EntityFrameworkCore;
using ResearchManage.Infrustructure;
using ResearchManage.Application;
using ResearchManage.Services;
using ResearchManage.Infrustructure.Data;
using System;
using ResearchManage.Application.Middleware;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

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
builder.Services.AddApplicationDependencies();
#endregion


#region Localization

builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt=>opt.ResourcesPath="");
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


   } );

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
var optionsLz=app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (optionsLz != null)
app.UseRequestLocalization(optionsLz.Value);
#endregion

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
