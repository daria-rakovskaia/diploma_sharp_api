using diploma_sharp_api.AnalysisModels;

namespace diploma_sharp_api.Services.AnalysisService
{
    public interface IAnalysisService
    {
        CodeAnalysisResult AnalyzeCode(string code);
    }
}
