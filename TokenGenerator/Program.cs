using Microsoft.EntityFrameworkCore;
using TokenGenerator.TokenGenerator.Services.Implementations;
using TokenGenerator.TokenGenerator.Services.Interfaces;
using TokenGenerator.TokenGeneratorDataAccess;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add UserDbContext
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("Data Source=helloapp.db")));
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();