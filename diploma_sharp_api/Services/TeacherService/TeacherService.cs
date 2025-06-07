using diploma_sharp_api.Models;
using Microsoft.EntityFrameworkCore;

namespace diploma_sharp_api.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly HseExamProgContext context;

        public TeacherService(HseExamProgContext _context)
        {
            context = _context;
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            return await context.Teachers.ToListAsync();
        }
    }
}
