using Beta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beta.Services
{
    public interface IDemoService
    {
        Task AddDemoAsync(Demo demo);
        Task DeleteDemoAsync(int id);
        Task<Demo> GetDemoByIdAsync(int id);
        Task<IEnumerable<Demo>> GetDemosAsync();
        Task UpdateDemoAsync(Demo demo);
    }
}
