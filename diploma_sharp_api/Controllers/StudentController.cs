using diploma_sharp_api.Models;
using diploma_sharp_api.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace diploma_sharp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        [HttpGet("{groupId}")]
        public async Task<List<Student>> GetStudentsByGroupAsync(int groupId)
        {
            return await studentService.GetStudentsByGroupAsync(groupId);
        }
    }
}
