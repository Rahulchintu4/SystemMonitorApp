using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using SystemMonitorApp.Interfaces;
using SystemMonitorApp.Models;

namespace SystemMonitorApp.Plugins;

public class FileLoggerPlugin : IMonitorPlugin
{
    private static readonly ILog _logger =
        LogManager.GetLogger(typeof(FileLoggerPlugin));

    public Task ExecuteAsync(SystemMetric metric)
    {
        _logger.Info(
            $"CPU:{metric.CpuUsage}% " +
            $"RAM:{metric.RamUsedMB}MB " +
            $"DISK:{metric.DiskUsedGB}GB");

        return Task.CompletedTask;
    }
}
