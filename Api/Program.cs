using System;
using Api.Persistence;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        
        var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(
                connectionString,
                option => option.EnableRetryOnFailure()));
    })
    .Build();

host.Run();
