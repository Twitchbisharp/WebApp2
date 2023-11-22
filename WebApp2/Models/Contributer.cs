using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp2.Models
{
    public class Contributer
    {
        [Key]
        [JsonPropertyName("ContributerId")]
        public int ContributerId { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        //// Navigation property
        //[JsonPropertyName("Collections")]
        //public virtual List<Collection>? Collections{ get; set; }

    }

}