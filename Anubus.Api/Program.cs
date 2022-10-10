using Anubus.Api;
using Anubus.Services.Logging;
using Anubus.Services.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var startUp = new StartUp(builder.Host);

startUp.ConfigureLogger(builder.Services);

startUp.ConfigureDatabse(builder.Configuration, builder.Services);

startUp.ConfigureWebPartServices(builder.Services);


builder.Services.AddSingleton<SecuritySettings>(_ => 
    new SecuritySettings
    {
        WithoutIdm = true,
    });


var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);


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
