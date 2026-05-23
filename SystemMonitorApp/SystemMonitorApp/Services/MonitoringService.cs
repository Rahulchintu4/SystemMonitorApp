using Hardware.Info;
using SystemMonitorApp.Interfaces;
using SystemMonitorApp.Models;

namespace SystemMonitorApp.Services;

public class MonitoringService : IMonitoringService
{
    private readonly HardwareInfo _hardwareInfo;

    public MonitoringService()
    {
        _hardwareInfo = new HardwareInfo();
    }

    public async Task<SystemMetric> GetMetricsAsync()
    {
        await Task.Delay(100);

        _hardwareInfo.RefreshMemoryStatus();

        var totalMemory =
            _hardwareInfo.MemoryStatus.TotalPhysical;

        var availableMemory =
            _hardwareInfo.MemoryStatus.AvailablePhysical;

        var usedMemory =
            totalMemory - availableMemory;

        double ramUsedMB =
            usedMemory / 1024.0 / 1024.0;

        double totalRamMB =
            totalMemory / 1024.0 / 1024.0;

        double ramUsagePercent =
            (ramUsedMB / totalRamMB) * 100;

        var drive =
            DriveInfo.GetDrives()
                .FirstOrDefault(d =>
                    d.IsReady &&
                    d.DriveType == DriveType.Fixed);

        double diskUsedGB = 0;

        if (drive != null)
        {
            diskUsedGB =
                (drive.TotalSize - drive.AvailableFreeSpace)
                / 1024.0 / 1024.0 / 1024.0;
        }

        return new SystemMetric
        {
            CpuUsage =
                GetCpuUsage(),

            RamUsedMB =
                Math.Round(ramUsedMB, 2),

            DiskUsedGB =
                Math.Round(diskUsedGB, 2),

            Timestamp = DateTime.Now
        };
    }

    private double GetCpuUsage()
    {
        return Random.Shared.Next(1, 100);
    }
}