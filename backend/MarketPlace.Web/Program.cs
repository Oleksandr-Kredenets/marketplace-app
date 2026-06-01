using Microsoft.EntityFrameworkCore;
using MarketPlace.Infrastructure;
using MarketPlace.Application.Extensions;
namespace MarketPlace.Web;

public static class Program
{
    public static void Main(string []args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        string? connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
        builder.Services.AddDbContext<MarketPlaceDbContext>(options =>
            options.UseNpgsql(connectionString));

        builder.Services.AddProjectServices();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.Environment.EnvironmentName = "Development";

        if (app.Environment.IsDevelopment())
        {
            app.UseCors(builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        app.Run();
    }
}