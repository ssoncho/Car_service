using CarServiceWebConsole.Data;

namespace CarServiceWebConsole.Services.WorkerParticipationService
{
    public class WorkerParticipationService : IWorkerParticipationService
    {
        private readonly DataContext _context;

        public WorkerParticipationService(DataContext context)
        {
            _context = context;
        }

        public async Task<WorkerParticipation> CreateWorkerParticipationAsync(WorkerParticipation workerParticipation)
        {
            _context.WorkerParticipations.Add(workerParticipation);
            await _context.SaveChangesAsync();
            return workerParticipation;
        }
    }
}
