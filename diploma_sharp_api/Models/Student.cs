using System.Text.Json.Serialization;

namespace diploma_sharp_api.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
