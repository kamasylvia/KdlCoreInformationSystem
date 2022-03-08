﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WorkshopSchedule.Data;
using WorkshopSchedule.Data.Initializers;


// Serilog
IConfiguration _configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
        optional: true,
        reloadOnChange: true
    )
    .AddEnvironmentVariables()
    .Build();


Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(_configuration)
    .Enrich.FromLogContext()
    .CreateLogger();


try
{
    Log.Information("Starting web host");

    // StartUp
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(
        (hostingContext, loggerConfig) =>
            loggerConfig.ReadFrom.Configuration(hostingContext.Configuration)
    );

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add HttpClient
    builder.Services.AddHttpClient();

    // Add DbContexts
    builder.Services.AddDbContext<ApplicationDbContext>(
        options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
            // var connectionString = builder.Configuration.GetConnectionString("MySQL");
            // options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // Register the entity sets needed by OpenIddict.
            // Note: use the generic overload if you need
            // to replace the default OpenIddict entities.
            // options.UseOpenIddict();
        }
    );

    // MediatR
    builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

    var app = builder.Build();

    // Seed database
    // await app.Services.SeedDbContextAsync(builder.Configuration, builder.Environment);

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
}
catch (System.Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
