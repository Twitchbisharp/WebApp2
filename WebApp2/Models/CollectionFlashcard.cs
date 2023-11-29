using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApp2.Models
{
    public class CollectionFlashcard
    {
        [Key]
        [JsonPropertyName("CollectionFlashcardId")]
        public int CollectionFlashcardId { get; set; }


        [JsonPropertyName("FlashcardId")]
        public int FlashcardId { get; set; }

        //Navigation property
        public virtual Flashcard? Flashcard { get; set; } = default!;

        [JsonPropertyName("CollectionId")]
        public int CollectionId { get; set; }

        //Navigation property
        // This creates Json-loop
        public virtual Collection? Collection { get; set; } = default!;
    }
}
