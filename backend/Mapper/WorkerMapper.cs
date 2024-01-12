using CarServiceWebConsole.DTO.GetWorkers;

namespace CarServiceWebConsole.Mapper
{
    public static class WorkerMapper
    {
        public static GetWorkersDto ToDto(this List<Worker> workers)
        {
            var workerDtos = workers.ConvertAll(worker => new GetWorkersWorkerDto
            {
                Name = worker.Name,
                Patronymic = worker.Patronymic,
                Surname = worker.Surname
            });
            return new GetWorkersDto { Workers = workerDtos };
        }
    }
}
