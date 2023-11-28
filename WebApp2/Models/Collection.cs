using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp2.Models
{
    public class Collection
    {
        [Key]
        [JsonPropertyName("CollectionId")]
        public int CollectionId { get; set; }

        [JsonPropertyName("CollectionDate")]
        public string CollectionDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

        [JsonPropertyName("CollectionName")]
        public string CollectionName { get; set; } = string.Empty;

        [JsonPropertyName("ContributerId")]
        public int ContributerId { get; set; }

        //Navigation property
        [JsonPropertyName("Contributers")]
        public virtual List<Contributer>? Contributers { get; set; } = default!;

        //[JsonPropertyName("CollectionFlashcardId")]
        //public int CollectionFlashcardId { get; set; } = 0;

        //Navigation property 
        [JsonPropertyName("CollectionFlashcard")]
        public virtual List<CollectionFlashcard>? CollectionFlashcard { get; set; } = default!;

        [JsonPropertyName("TotalFlashcards")]
        public int TotalFlashcards { get; set; } = 0;
    }

}
