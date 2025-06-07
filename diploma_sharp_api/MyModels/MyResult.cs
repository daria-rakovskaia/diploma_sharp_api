namespace diploma_sharp_api.MyModels
{
    public class MyResult
    {
        public int? StudentId { get; set; }

        public int? TeacherId { get; set; }

        public int TaskId { get; set; }

        public string RecognizedCode { get; set; } = null!;

        public string AnalysisRes { get; set; } = null!;

        public string ScanPath { get; set; } = null!;

        public MyResult(int? studentId, int? teacherId, int taskId, string recognizedCode, string analysisRes, string scanPath)
        {
            StudentId = studentId;
            TeacherId = teacherId;
            TaskId = taskId;
            RecognizedCode = recognizedCode;
            AnalysisRes = analysisRes;
            ScanPath = scanPath;
        }
    }
}
