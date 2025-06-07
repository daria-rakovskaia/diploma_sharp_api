using diploma_sharp_api.Models;
using diploma_sharp_api.MyModels;
using diploma_sharp_api.Services.ResultService;
using Microsoft.AspNetCore.Mvc;

namespace diploma_sharp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {
        private readonly IResultService resultService;

        public ResultController(IResultService _resultService)
        {
            resultService = _resultService;
        }

        [HttpGet]
        public async Task<List<Result>> GetResultsAsync()
        {
            return await resultService.GetResultsAsync();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddResultAsync(MyResult result)
        {
            var addResult = await resultService.AddResultAsync(result);
            if (!addResult)
                return BadRequest();
            return Ok(result);
        }
    }
}
