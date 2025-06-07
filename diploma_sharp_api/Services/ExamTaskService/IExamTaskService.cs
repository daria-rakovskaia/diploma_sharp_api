using diploma_sharp_api.Models;

namespace diploma_sharp_api.Services.ExamTaskService
{
    public interface IExamTaskService
    {
        Task<List<ExamTask>> GetExamTasksAsync(int variantId);
        Task<ExamTask> GetExamTaskAsync(int taskId);
    }
}
