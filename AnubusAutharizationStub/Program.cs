using Anubus.Db;
using AnubusAutharizationStub;

var builder = WebApplication.CreateBuilder(args);

Anubus.Services.Logging.LoggerConfiguration.ConfigureWebApiPart();
Serilog.SerilogHostBuilderExtensions.UseSerilog(builder.Host);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.DefaultPgConfiguration<AuthStubDbContext>(builder.Configuration.GetSection("AUTH_STUB_DB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
