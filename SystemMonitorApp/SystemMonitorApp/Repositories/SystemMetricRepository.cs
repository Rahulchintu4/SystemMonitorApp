using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SystemMonitorApp.Database;
using SystemMonitorApp.Interfaces;
using SystemMonitorApp.Models;

namespace SystemMonitorApp.Repositories;

public class SystemMetricRepository
    : IRepository<SystemMetric>
{
    private readonly AppDbContext _context;

    public SystemMetricRepository(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(SystemMetric entity)
    {
        _context.SystemMetrics.Add(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<List<SystemMetric>> GetAllAsync()
    {
        return await _context.SystemMetrics.ToListAsync();
    }
}
