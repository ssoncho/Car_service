using CarServiceWebConsole.Data;
using Microsoft.EntityFrameworkCore;

namespace CarServiceWebConsole.Services.WorkerService
{
    public class WorkerService : IWorkerService
    {
        private readonly DataContext _context;

        public WorkerService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Worker>> GetAllWorkersAlphabeticallyAsync()
        {
            var workers = await _context.Workers
                .OrderBy(worker => worker.Surname)
                .ToListAsync();
            return workers;
        }

        public async Task<Worker> GetWorkerByFullName(string name, string? patronymic, string surname)
        {
            var worker = await _context.Workers.FirstOrDefaultAsync(w => 
                w.Name == name 
                && w.Patronymic == patronymic 
                && w.Surname == surname);
            if (worker == null)
                throw new NotFoundException("Worker", $"{name} {patronymic} {surname}");
            return worker;
        }
    }
}
