using System.Text.Json.Serialization;

namespace diploma_sharp_api.Models;

public partial class Variant
{
    public int Id { get; set; }

    public int InitialYear { get; set; }

    public int Module { get; set; }

    public int VariantNum { get; set; }

    [JsonIgnore]
    public virtual ICollection<ExamTask> ExamTasks { get; set; } = new List<ExamTask>();
}
