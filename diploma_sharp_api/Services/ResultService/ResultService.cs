using diploma_sharp_api.Models;
using diploma_sharp_api.MyModels;
using Microsoft.EntityFrameworkCore;

namespace diploma_sharp_api.Services.ResultService
{
    public class ResultService : IResultService
    {
        private readonly HseExamProgContext context;

        public ResultService(HseExamProgContext _context)
        {
            context = _context;
        }

        public async Task<bool> AddResultAsync(MyResult result)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var workResult = new Result(result.StudentId, result.TeacherId, result.TaskId, result.RecognizedCode,
                                        result.AnalysisRes, result.ScanPath, today);
            context.Results.Add(workResult);
            return await context.SaveChangesAsync() >= 1;
        }

        public async Task<List<Result>> GetResultsAsync()
        {
            return await context.Results
                                .Include(r => r.Student)
                                .Include(r => r.Student.Group)
                                .Include(r => r.Task)
                                .Include(r => r.Task.Variant)
                                .ToListAsync();
        }
    }
}
