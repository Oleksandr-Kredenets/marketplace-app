using Microsoft.EntityFrameworkCore;
using MarketPlace.Persistance;
using MarketPlace.Application.Extensions;
namespace MarketPlace.API;

public static class Program
{
    public static void Main(string []args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        string? connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
        Console.WriteLine($"Connection string: '{connectionString}'");
        builder.Services.AddDbContext<MarketPlaceDbContext>(options =>
            options.UseNpgsql(connectionString));

        builder.Services.AddProjectServices();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.Environment.EnvironmentName = "Development";

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        app.Run();
    }
}