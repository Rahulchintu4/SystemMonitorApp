using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitorApp.Models;

namespace SystemMonitorApp.Interfaces;

public interface IMonitoringService
{
    Task<SystemMetric> GetMetricsAsync();
}
