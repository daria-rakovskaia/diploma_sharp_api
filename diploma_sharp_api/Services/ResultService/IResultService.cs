using diploma_sharp_api.Models;
using diploma_sharp_api.MyModels;

namespace diploma_sharp_api.Services.ResultService
{
    public interface IResultService
    {
        Task<bool> AddResultAsync(MyResult result);
        Task<List<Result>> GetResultsAsync();
    }
}
