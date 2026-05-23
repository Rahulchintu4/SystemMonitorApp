using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemMonitorApp.Interfaces;
using SystemMonitorApp.Models;

namespace SystemMonitorApp.Services;

public class MonitoringWorker : BackgroundService
{
    private readonly IMonitoringService _monitoringService;

    private readonly IEnumerable<IMonitorPlugin> _plugins;

    private readonly IServiceScopeFactory _scopeFactory;

    public MonitoringWorker(
        IMonitoringService monitoringService,
        IEnumerable<IMonitorPlugin> plugins,
        IServiceScopeFactory scopeFactory)
    {
        _monitoringService = monitoringService;

        _plugins = plugins;

        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var metric =
                    await _monitoringService
                        .GetMetricsAsync();

                Console.Clear();

                Console.WriteLine(
                    "===== SYSTEM MONITOR =====");

                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine(
                    $"CPU Usage : {metric.CpuUsage}%");

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine(
                    $"RAM Usage : {metric.RamUsedMB} MB");

                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine(
                    $"Disk Usage : {metric.DiskUsedGB} GB");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(
                    $"Time : {metric.Timestamp}");

                Console.ResetColor();

                using var scope =
                    _scopeFactory.CreateScope();

                var repository =
                    scope.ServiceProvider
                        .GetRequiredService<
                            IRepository<SystemMetric>>();

                await repository.AddAsync(metric);

                var tasks = _plugins
                    .Select(plugin =>
                        plugin.ExecuteAsync(metric));

                await Task.WhenAll(tasks);

                await Task.Delay(5000, stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error : {ex.Message}");
            }
        }
    }
}