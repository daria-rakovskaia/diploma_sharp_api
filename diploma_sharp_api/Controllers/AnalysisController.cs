using diploma_sharp_api.Services.AnalysisService;
using Microsoft.AspNetCore.Mvc;

namespace diploma_sharp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalysisController : ControllerBase
    {
        public readonly IAnalysisService _analysisService;

        public AnalysisController(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        [HttpPost]
        public IActionResult AnalyzeCode(string code)
        {
            var result = _analysisService.AnalyzeCode(code);
            return Ok(result);
        }
    }
}
