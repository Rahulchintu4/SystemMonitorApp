using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using SystemMonitorApp.Interfaces;
using SystemMonitorApp.Models;

namespace SystemMonitorApp.Plugins;

public class ApiPlugin : IMonitorPlugin
{
    private readonly HttpClient _httpClient;

    public ApiPlugin(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task ExecuteAsync(SystemMetric metric)
    {
        var json =
            JsonSerializer.Serialize(metric);

        var content =
            new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

        await _httpClient.PostAsync(
            "https://localhost:7000/api/systemmetrics",
            content);
    }
}