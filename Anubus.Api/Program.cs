using Anubus.Api;
using Anubus.Api.Notifier;
using Anubus.Services.Logging;
using Anubus.Services.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

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



builder.Services.AddSignalR()
    .AddJsonProtocol(opt => opt.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddTransient<INotifyClient, NotifyClient>();



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

app.UseCors(b => {
    b.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    //b.AllowAnyHeader();
    ////b.AllowAnyMethod();
    ////b.AllowCredentials();
    //b.AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<Anubus.Api.Notifier.NotifyHub>("/notify");


app.Run();
