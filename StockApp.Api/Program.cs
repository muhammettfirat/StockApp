using StockApp.Api.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Persistance.Repositories;
using MediatR;
using System.Reflection;
using AutoMapper;
using StockApp.Api.Core.Application.AutoMapperProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StockApp.Api.Infrastructure.Tools;
using StockApp.Api.Persistance.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Geliþtirme ortamý için
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Async(c => c.File("Persistance/Logs/logs.txt"))
    .WriteTo.Async(c => c.Console())
    .CreateLogger();
Log.Information("Starting web host.");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = false;
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtDefaults.ValidAudience,
        ValidIssuer= JwtDefaults.ValidIssuer,
        ClockSkew=TimeSpan.Zero,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtDefaults.Key)),
        ValidateIssuerSigningKey=true,
        ValidateLifetime=true,
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StockAppContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("StockApp"));
});
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(option =>
{
    option.AddProfiles(new List<Profile>()
    {
        new AutoMapperProfile()
    });
});
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<StockAppContext>();
await db.Database.MigrateAsync();
var seed = scope.ServiceProvider.GetRequiredService<DataSeeder>();
seed.SeedData();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
