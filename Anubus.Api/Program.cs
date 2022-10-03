using Anubus.Api;
using Anubus.Api.Db;
using Anubus.Db;
using Anubus.Services.Logging;
using Anubus.Services.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

Anubus.Services.Logging.LoggerConfiguration.ConfigureWebApiPart();

Log.Default.Here().Fatal("Start Anubus");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);
});

Serilog.SerilogHostBuilderExtensions.UseSerilog(builder.Host);
builder.Services.AddTransient<Anubus.ILogger>(_ => Log.Default);

builder.Services.AddSingleton<SecuritySettings>(_ => 
    new SecuritySettings
    {
        WithoutIdm = true,
    });

//builder.Services.DefaultPgConfiguration<AnubusContext>();
//builder.Services.AddTransient<IDbAnubusContextFactory<IGrbsDbContext>>(
//    s => new DbAnubusContextFactory<IGrbsDbContext, AnubusContext>(s.GetRequiredService<IDbContextFactory<AnubusContext>>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<LogAdditionalInfoMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
