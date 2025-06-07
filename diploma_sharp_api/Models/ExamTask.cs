using System.Text.Json.Serialization;

namespace diploma_sharp_api.Models;

public partial class ExamTask
{
    public int Id { get; set; }

    public int VariantId { get; set; }

    public int TaskNum { get; set; }

    public string TaskText { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual Variant Variant { get; set; } = null!;
}
