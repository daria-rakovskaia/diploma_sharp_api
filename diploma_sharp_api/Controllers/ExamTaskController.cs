using diploma_sharp_api.Models;
using diploma_sharp_api.Services.ExamTaskService;
using Microsoft.AspNetCore.Mvc;

namespace diploma_sharp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamTaskController : ControllerBase
    {
        private readonly IExamTaskService examTaskService;

        public ExamTaskController(IExamTaskService _examTaskService)
        {
            examTaskService = _examTaskService;
        }

        [HttpGet("variant/{variantId}")]
        public async Task<List<ExamTask>> GetExamTasksAsync(int variantId)
        {
            return await examTaskService.GetExamTasksAsync(variantId);
        }

        [HttpGet("id/{taskId}")]
        public async Task<ExamTask> GetExamTaskAsync(int taskId)
        {
            return await examTaskService.GetExamTaskAsync(taskId);
        }
    }
}
