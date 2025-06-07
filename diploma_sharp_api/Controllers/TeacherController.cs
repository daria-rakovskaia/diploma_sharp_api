using diploma_sharp_api.Models;
using diploma_sharp_api.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;

namespace diploma_sharp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService _teacherService)
        {
            teacherService = _teacherService;
        }

        [HttpGet]
        public async Task<List<Teacher>> GetTeachersAsync()
        {
            return await teacherService.GetTeachersAsync();
        }
    }
}
