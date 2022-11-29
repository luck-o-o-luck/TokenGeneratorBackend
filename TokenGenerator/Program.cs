using Microsoft.EntityFrameworkCore;
using TokenGenerator.TokenGenerator.Services.Implementations;
using TokenGenerator.TokenGenerator.Services.Interfaces;
using TokenGenerator.TokenGeneratorDataAccess;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var defaultCorsPolicyName = "DefaultName";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        defaultCorsPolicyName,
        builder =>
        {
            builder.WithOrigins(
                    configuration.GetSection("http://localhost:3000")
                        .GetChildren()
                        .Select(x => x.Value)
                        .ToArray())
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});

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

app.UseCors(defaultCorsPolicyName);

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();