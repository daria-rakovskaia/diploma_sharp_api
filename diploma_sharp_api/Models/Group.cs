using System.Text.Json.Serialization;

namespace diploma_sharp_api.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
