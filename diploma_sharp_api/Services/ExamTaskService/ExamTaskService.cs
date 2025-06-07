using diploma_sharp_api.Models;
using Microsoft.EntityFrameworkCore;

namespace diploma_sharp_api.Services.ExamTaskService
{
    public class ExamTaskService : IExamTaskService
    {
        private readonly HseExamProgContext context;

        public ExamTaskService(HseExamProgContext _context)
        {
            context = _context;
        }

        public async Task<ExamTask> GetExamTaskAsync(int taskId)
        {
            return await context.ExamTasks.FirstOrDefaultAsync(et => et.Id == taskId);
        }

        public async Task<List<ExamTask>> GetExamTasksAsync(int variantId)
        {
            return await context.ExamTasks
                                .Where(et => et.VariantId == variantId)
                                .ToListAsync();
        }
    }
}
