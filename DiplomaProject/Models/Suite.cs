namespace TestProject1.Models;

public class Suite
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("announcement")] public string Announcement { get; set; }

}