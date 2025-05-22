namespace diploma_sharp_api.AnalysisModels
{
    public class CodeAnalysisResult
    {
        public List<CodeIssue> Errors { get; set; } = new();
    }
}
