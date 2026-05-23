using log4net.Config;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemMonitorApp.Database;
using SystemMonitorApp.Interfaces;
using SystemMonitorApp.Models;
using SystemMonitorApp.Plugins;
using SystemMonitorApp.Repositories;
using SystemMonitorApp.Services;

XmlConfigurator.Configure(
    new FileInfo("log4net.config"));
var host = Host.CreateDefaultBuilder(args)

    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                context.Configuration
                    .GetConnectionString(
                        "DefaultConnection")));

        services.AddSingleton<IMonitoringService,
            MonitoringService>();

        services.AddSingleton<IMonitorPlugin,
            FileLoggerPlugin>();

        services.AddHttpClient<ApiPlugin>();

        services.AddSingleton<IMonitorPlugin,
            ApiPlugin>();

        services.AddScoped<IRepository<SystemMetric>,
            SystemMetricRepository>();

        services.AddHostedService<MonitoringWorker>();
    })

    .Build();

using (var scope = host.Services.CreateScope())
{
    var db =
        scope.ServiceProvider
            .GetRequiredService<AppDbContext>();

    db.Database.Migrate();
}

await host.RunAsync();