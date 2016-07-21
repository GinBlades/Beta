using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beta.Models;
using Microsoft.EntityFrameworkCore;

namespace Beta.Services
{
    public class DemoService : IDemoService {
        private DemoContext _demoContext;

        public DemoService(DemoContext demoContext) {
            _demoContext = demoContext;
        }

        public async Task AddDemoAsync(Demo demo) {
            _demoContext.Demos.Add(demo);
            await _demoContext.SaveChangesAsync();
        }

        public async Task DeleteDemoAsync(int id) {
            Demo demo = _demoContext.Demos.Single(d => d.Id == id);
            _demoContext.Demos.Remove(demo);
            await _demoContext.SaveChangesAsync();
        }

        public async Task<Demo> GetDemoByIdAsync(int id) {
            return await _demoContext.Demos.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Demo>> GetDemosAsync() {
            var demos = _demoContext.Demos;
            return await demos.ToArrayAsync();
        }

        public async Task UpdateDemoAsync(Demo demo) {
            _demoContext.Entry(demo).State = EntityState.Modified;
            await _demoContext.SaveChangesAsync();
        }
    }
}
