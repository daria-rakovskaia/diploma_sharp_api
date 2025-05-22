namespace diploma_sharp_api.AnalysisModels
{
    public class CodeIssue
    {
        public string? Id { get; set; }
        public string? Message { get; set; }
        public string? Severity { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }
}


