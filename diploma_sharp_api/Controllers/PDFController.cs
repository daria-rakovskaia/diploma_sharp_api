using diploma_sharp_api.PDFModels;
using diploma_sharp_api.Services.PDFService;
using Microsoft.AspNetCore.Mvc;

namespace diploma_sharp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PDFController : ControllerBase
    {
        private readonly IPDFService pdfService;

        public PDFController(IPDFService _pdfService)
        {
            pdfService = _pdfService;
        }

        [HttpPost]
        public IActionResult GetPDF([FromBody] PDFBody result)
        {
            if (string.IsNullOrEmpty(result.Result))
                return BadRequest("Text cannot be empty");
            var pdfBytes = pdfService.GetPDF(result);
            return File(pdfBytes, "application/pdf", result.OutputPath);
        }
    }
}
