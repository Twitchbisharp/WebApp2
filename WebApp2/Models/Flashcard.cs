using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp2.Models;

public class Flashcard
{
    [Key]
    [JsonPropertyName("FlashcardId")]
    public int FlashcardId { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("Description")]
    public string? Description { get; set; }
    [JsonPropertyName("ImageUrl")]
    public string? ImageUrl { get; set; }
}
