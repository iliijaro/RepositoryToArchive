namespace TestProject1.Models;

public class Milestone
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    public string Reference { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
}
