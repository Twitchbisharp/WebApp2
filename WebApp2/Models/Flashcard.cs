using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp2.Models;

public class Flashcard
{
    [Key]
    [JsonPropertyName("FlashcardId")]
    public int FlashcardId { get; set; }
    [JsonPropertyName("Name")]
    [StringLength(20)]
    [RegularExpression(@"[0-9a-zA-ZæøåÆØÅ. \-]{2,15}")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("Description")]
    [StringLength(20)]
    [RegularExpression(@"[0-9a-zA-ZæøåÆØÅ. \-]{2,15}")]
    public string? Description { get; set; }
    [JsonPropertyName("ImageUrl")]
    public string? ImageUrl { get; set; }
}

