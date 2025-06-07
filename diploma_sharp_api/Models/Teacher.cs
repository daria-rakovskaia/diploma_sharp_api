using System.Text.Json.Serialization;

namespace diploma_sharp_api.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    [JsonIgnore]
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
