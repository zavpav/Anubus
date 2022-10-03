using AnubusAutharizationStub;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




string host = "localhost";
int port = 5441;
string database = "authStub";
string username = "postgres";
string password = "123456";

builder.Services.AddPooledDbContextFactory<AuthStubDbContext>(opt => opt
        .UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}")
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging(true)
        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
    );





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
