using diploma_sharp_api.Models;
using Microsoft.EntityFrameworkCore;

namespace diploma_sharp_api.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly HseExamProgContext context;

        public StudentService(HseExamProgContext _context)
        {
            context = _context;
        }

        public async Task<List<Student>> GetStudentsByGroupAsync(int groupId)
        {
            return await context.Students
                                .Where(s => s.Group.Id == groupId)
                                .ToListAsync();
        }
    }
}
