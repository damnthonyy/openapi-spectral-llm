using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Writers;
using Microsoft.OpenApi;
using Application.Interfaces;
using Bank.Infrastructure.Repositories;
using Bank.Application.UseCases;
using Microsoft.OpenApi.Models;

namespace OpenApiGenerator;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configurer les services (identique à Program.cs du projet principal)
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Bank API",
                Description = "An ASP.NET Core Web API for managing Bank items",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });
        });
        builder.Services.AddSingleton<IAccountRepository, InMemoryAccountRepository>();
        builder.Services.AddTransient<AccountUseCase>();

        var app = builder.Build();

        // Mapper les contrôleurs (nécessaire pour que Swagger les détecte)
        app.MapControllers();

        // Générer le document OpenAPI
        var swaggerProvider = app.Services.GetRequiredService<ISwaggerProvider>();
        var swaggerDoc = swaggerProvider.GetSwagger("v1");

        // Sérialiser en JSON dans le répertoire racine du projet Bank
        // Utiliser le répertoire du projet plutôt que le répertoire courant
        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
        var outputPath = Path.Combine(projectRoot, "openapi.json");
        
        using var streamWriter = new StreamWriter(outputPath);
        var jsonWriter = new OpenApiJsonWriter(streamWriter);
        swaggerDoc.SerializeAsV3(jsonWriter);

        Console.WriteLine($"✓ OpenAPI file generated: {outputPath}");
    }
}