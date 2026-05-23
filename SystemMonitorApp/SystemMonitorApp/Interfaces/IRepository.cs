using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SystemMonitorApp.Interfaces;

public interface IRepository<T>
{
    Task AddAsync(T entity);

    Task<List<T>> GetAllAsync();
}
