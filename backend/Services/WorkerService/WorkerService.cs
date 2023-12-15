using CarServiceWebConsole.Data;

namespace CarServiceWebConsole.Services.WorkerService
{
    public class WorkerService : IWorkerService
    {
        private readonly DataContext _context;

        public WorkerService(DataContext context)
        {
            _context = context;
        }

        public Worker GetWorkerById(int id)
        {
            var worker = _context.Workers.Find(id);
            return worker;
        }
    }
}
