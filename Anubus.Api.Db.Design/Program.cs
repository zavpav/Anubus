using Anubus;
using Anubus.Api.Db;
using Anubus.Db;

Anubus.Services.Logging.LoggerConfiguration.ConfigureWebApiPart();
Log.Default.Here().Fatal("Start DbDesign Anubus");


var builder = WebApplication.CreateBuilder(args);

builder.Services.DefaultPgConfiguration<AnubusContext>();

var app = builder.Build();
app.Run();
