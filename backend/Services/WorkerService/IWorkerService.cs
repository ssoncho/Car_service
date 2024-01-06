namespace CarServiceWebConsole.Services.WorkerService
{
    public interface IWorkerService
    {
        Task<Worker> GetWorkerByFullName(string name, string? patronymic, string surname);
    }
}
