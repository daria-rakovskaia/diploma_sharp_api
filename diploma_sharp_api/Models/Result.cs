namespace diploma_sharp_api.Models;

public partial class Result
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? TeacherId { get; set; }

    public int TaskId { get; set; }

    public string RecognizedCode { get; set; } = null!;

    public string AnalysisRes { get; set; } = null!;

    public string ScanPath { get; set; } = null!;

    public DateOnly CheckDate { get; set; }

    public virtual Student? Student { get; set; }

    public virtual ExamTask Task { get; set; } = null!;

    public virtual Teacher? Teacher { get; set; }

    public Result(int? studentId, int? teacherId, int taskId, string recognizedCode, string analysisRes, string scanPath, DateOnly checkDate)
    {
        StudentId = studentId;
        TeacherId = teacherId;
        TaskId = taskId;
        RecognizedCode = recognizedCode;
        AnalysisRes = analysisRes;
        ScanPath = scanPath;
        CheckDate = checkDate;
    }
}
