using diploma_sharp_api.Models;
using diploma_sharp_api.Services.VariantService;
using Microsoft.AspNetCore.Mvc;

namespace diploma_sharp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VariantController : ControllerBase
    {
        private readonly IVariantService variantService;

        public VariantController(IVariantService _variantService)
        {
            variantService = _variantService;
        }

        [HttpGet]
        public async Task<List<Variant>> GetVariantsAsync()
        {
            return await variantService.GetVariantsAsync();
        }
    }
}
