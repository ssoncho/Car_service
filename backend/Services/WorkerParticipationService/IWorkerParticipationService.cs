namespace CarServiceWebConsole.Services.WorkerParticipationService
{
    public interface IWorkerParticipationService
    {
        Task<WorkerParticipation> CreateWorkerParticipationAsync(WorkerParticipation workerParticipation);
    }
}
