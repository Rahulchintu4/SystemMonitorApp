using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitorApp.Models;

public class SystemMetric
{
    public int Id { get; set; }

    public double CpuUsage { get; set; }

    public double RamUsedMB { get; set; }

    public double DiskUsedGB { get; set; }

    public DateTime Timestamp { get; set; }
}
