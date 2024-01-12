using CarServiceWebConsole.DTO.GetWorkers;
using CarServiceWebConsole.Mapper;
using CarServiceWebConsole.Services.WorkerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceWebConsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public async Task<ActionResult<GetWorkersDto>> GetAllWorkers()
        {
            var workers = await _workerService.GetAllWorkersAlphabeticallyAsync();
            var workersDto = workers.ToDto();
            return workersDto;
        }
    }
}
